mainApp.controller("DoctorsController", ["$scope", "$filter", "$http", "$document", "$window", "$timeout", "doctorsService", "turnsService", "loginService", function ($scope, $filter, $http, $document, $window, $timeout, doctorsService, turnsService, loginService) {

    $scope.accessToken = sessionStorage.getItem('accessToken');

    $scope.SearchTerm = "";
    $scope.Hospital = "";
    $scope.Clinic = "";
    $scope.City = "";
    $scope.Expertise = "";
    $scope.HasEmptyTurn = false;
    $scope.Gender = 2; // 2 = Both, 1 = Male, 0 = Female

    // Pagination
    $scope.items = 1;
    $scope.copy_items = [];
    $scope.limit = 9;
    $scope.pages = [];
    $scope.navigators = { prev: { state: true }, next: { state: true } };

    /**
    * calculate the number of pages for us and 
    * then set the first one as our active page
    */
    $scope.paginate = function () {
        $scope.pages = [];//clear it here resetting
        var n = Math.ceil($scope.items / $scope.limit);
        for (i = 0; i < n; i++) {
            $scope.pages.push({ start: (i * $scope.limit), page: i + 1, active: false });
        }
    }

    /**
    * this helps to set the wanted page number to be active
    */
    $scope.setPageActive = function (page) {
        index = page - 1;
        var n = $scope.pages.length;
        var previous_page = 1;
        for (i = 0; i < n; i++) {
            if ($scope.pages[i].active)
                current_page = $scope.pages[i].page;

            if (i == index)
                $scope.pages[i].active = true;
            else
                $scope.pages[i].active = false;
        }

        // Get Doctors Here And Copy Them To Copy_Items       
        $scope.SearchDoctors(index, false);
    }

    /**
    * this is triggered when the user hit on the prev button
    * this only works when the navigators.prev.state is true
    */
    $scope.prev = function () {
        if ($scope.navigators.prev.state) {
            $scope.setPageActive($scope.getCurrentPage() - 1);
        }
    }

    /**
     * this is triggered when the user hit on the next button
     * this only works when the navigators.next.state is true
     */
    $scope.next = function () {
        if ($scope.navigators.next.state) {
            $scope.setPageActive($scope.getCurrentPage() + 1);
        }
    }

    /**
     * this returns the current active page
     */
    $scope.getCurrentPage = function () {
        for (i = 0; i < $scope.pages.length; i++) {
            if ($scope.pages[i].active) {
                return i + 1;
            }
        }
    }

    // ==================================================================================
    $scope.SearchDoctors = function (pageIndex, renderPagination) {
        waitingUI();
        var filterModel = JSON.stringify({
            SearchTerm: $scope.SearchTerm,
            Expertise: $scope.Expertise,
            Clinic: $scope.Clinic,
            Hospital: $scope.Hospital,
            City: $scope.City,
            HasEmptyTurn: $scope.HasEmptyTurn,
            Gender: $scope.Gender
        });
        doctorsService.search(filterModel, pageIndex, $scope.limit).then(function (response) {

            $scope.items = response.data.totalCount;

            if (renderPagination == true) {
                $scope.copy_items = [];
                $scope.pages = [];
                $scope.paginate();
                $scope.setPageActive(1);
            }

            //keep it there so we dont mess with the original record
            $scope.copy_items = angular.copy(response.data.doctors);

            $scope.navigators["next"].state = pageIndex < ($scope.pages.length - 1) ? true : false;
            $scope.navigators["prev"].state = pageIndex > 0 ? true : false;

        }, function (err) {
            Snackbar.show({ text: err.data.ExceptionMessage, backgroundColor: '#FF3333', pos: 'top-center', showAction: false });
        }).finally(function () {
            waitingDoneUI();
        });
    }

    $scope.GetDetails = function (id) {
        waitingUI();
        $http({
            method: 'GET',
            url: "/Doctors/Details/" + id,
        }).success(function (data, status, headers, config) {
            var commonModal = $("#doctorDetailModal");
            commonModal.find('.modal-body').html(data);
            commonModal.modal({backdrop: 'static', keyboard: false});
        }).error(function (data, status, headers, config) {
            Snackbar.show({ text: data.ExceptionMessage, backgroundColor: '#FF3333', pos: 'top-center', showAction: false });
        }).finally(function () {
            waitingDoneUI();
        });
    }

    $scope.ReserveAppointment = function (doctor, locale) {
        $scope.ClearReservationData();
        var id = doctor.id;
        var accessToken = sessionStorage.getItem('accessToken');
        if (accessToken) {
            $scope.SelectedDoctor = doctor;
            waitingUI();
            doctorsService.reserve(id, locale).then(function (response) {
                $scope.ReserveData = response.data;
                if (response.data.ReservationType == 1) { // Selective Reserve               
                    $("#TurnDateInput").flatpickr({
                        minDate: response.data.SelectiveTurn.MinDate,
                        maxDate: response.data.SelectiveTurn.MaxDate,
                        enable: response.data.SelectiveTurn.ActiveDates,
                        onChange: function (selectedDates, dateStr, instance) {
                            $scope.GetBookableTurns(id, response.data.HealthServiceId, dateStr, locale);
                        }
                    });
                } else { // Sequentially
                    $scope.SelectedTurn = response.data.FirstTurn;
                }
                var commonModal = $("#makeAppointmentModal");
                commonModal.modal({backdrop: 'static', keyboard: false});
            }, function (err) {
                Snackbar.show({ text: err.data.ExceptionMessage, backgroundColor: '#FF3333', pos: 'top-center', showAction: false });
            }).finally(function () {
                waitingDoneUI();
            });
        } else {
            $scope.TryLogin(locale);
        }
    }

    $scope.GetBookableTurns = function (doctorId, healthServiceId, date, locale) {
        waitingUI();
        turnsService.bookableTurns(doctorId, healthServiceId, date, locale).then(function (response) {
            $scope.BookableTurns = response.data;
        }, function (err) {
            Snackbar.show({ text: err.data.ExceptionMessage, backgroundColor: '#FF3333', pos: 'top-center', showAction: false });
        }).finally(function () {
            waitingDoneUI();
        });
    }

    $scope.SetSelectedTurn = function (turn) {
        $scope.SelectedTurn = turn;
    }

    $scope.FinalBookAppointment = function (locale) {
        var accessToken = sessionStorage.getItem('accessToken');
        if (accessToken) {
            var mobile = accessToken;
            waitingUI();
            var bookingModel = JSON.stringify({
                DoctorId: $scope.ReserveData.DoctorId,
                Date: $scope.SelectedTurn.Date,
                StartTime: $scope.SelectedTurn.StartTime,
                EndTime: $scope.SelectedTurn.EndTime,
                Mobile: mobile,
                PolyclinicHealthServiceId: $scope.ReserveData.HealthServiceId
            });
            turnsService.finalBookAppointment(bookingModel, locale).then(function (response) {
                $scope.ClearReservationData();
                $scope.BookedAppointment = response.data;
            }, function (err) {
                Snackbar.show({ text: err.data.ExceptionMessage, backgroundColor: '#FF3333', pos: 'top-center', showAction: false });
            }).finally(function () {
                waitingDoneUI();
            });
        } else {
            $scope.TryLogin(locale);
        }
    }

    $scope.TryLogin = function (locale) {
        waitingUI();
        loginService.showLoginModal(locale).then(function (response) {
            var commonModal = $("#OtpLoginModal");
            commonModal.find(".modal-body").html(response.data);
            commonModal.modal({backdrop: 'static', keyboard: false});
        }, function (err) {
            Snackbar.show({ text: err.data.ExceptionMessage, backgroundColor: '#FF3333', pos: 'top-center', showAction: false });
        }).finally(function () {
            waitingDoneUI();
        });
    }

    $scope.ClearReservationData = function () {
        $scope.ReserveData = null;
        $scope.BookableTurns = null;
        $scope.SelectedTurn = null;
        $scope.BookedAppointment = null;
    }
}]);