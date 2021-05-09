
mainApp.controller("easyAppointmentsController", ["$scope", "$http", "$document", "$window", "$timeout", "loginService", "patientService", function ($scope, $http, $document, $window, $timeout, loginService, patientService) {

    var countDownTimer;

    if (isAccessDeniedToLocalStorage()) {
        var err = "Browser Does not support cookies";
        showMessageBox("هەڵە", err, "error");
    } else {

        checkReservedAlready();

        initializeBlockUI();

        /*try {
            appointmentsService.connect();
        } catch (e) {

        }*/

        getInitialData();
        GetHospitals();
        GetNewExpertises();
        GetProvinces();
    }



    //showMessageBox("توجه", "این سیستم فعلا آزمایشی و در حال آماده سازی جهت بهره برداری اولیه می باشد", "info");




    /// :: =======================================================================
    /// :: Check if access denied to localStorage
    /// :: =======================================================================
    function isAccessDeniedToLocalStorage() {
        var test = 't';
        try {
            localStorage.setItem('test', test);
            localStorage.removeItem('test');
            localStorage.setItem('Access', 'Allow');
            return false;
        } catch (e) {
            return true;
        }
    }




    /// :: =======================================================================
    /// :: Check if already user selected an appointment and haven't cancel it
    /// :: =======================================================================
    function checkReservedAlready() {
        var reservedAlready = localStorage.getItem("RA"); //RA means Reserved Appointment
        var reservedAlreadyForSelectedDoctor = localStorage.getItem("RAFSD"); //RAFSD means Reserved Appointment For Selected Doctor

        if (reservedAlready != null) {
            var reservedJson = JSON.parse(reservedAlready);
            /*
            reservedJson = 
            {
                hospital,
                clinic,
                policlinic,
                selectedTurn {
                    DayOfWeek,
                    Date,
                    StartTime,
                    EndTime,
                    ServiceSupplyId
                },
                reservationTime
    
            }
            reservedJson.selectedTurn.StartTime
            */
            //$.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

            $http({
                method: 'POST',
                url: "/Public/Appointment/retriveIPAForceOnReloadOrExitPage",
                data: JSON.stringify({
                    serviceSupplyId: reservedJson.selectedTurn.ServiceSupplyId,
                    date: reservedJson.selectedTurn.Date,
                    startTime: reservedJson.selectedTurn.StartTime,
                    reservationTime: reservedJson.reservationTime,
                    isSelectedDoctor: false
                })

            }).success(function (data, status, headers, config) {
                if (data.Result == "Success") {
                    $scope.SelectedTurn = null;
                    $scope.isReserving = false;
                    showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "info");
                    localStorage.removeItem('RA');
                    $timeout.cancel($scope.retriveIpaTimer);
                } else {
                    showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "error");
                }
                //$.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                checkReservedAlready()
                //$.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }

        if (reservedAlreadyForSelectedDoctor != null) {
            var reservedJson = JSON.parse(reservedAlreadyForSelectedDoctor);
            /*
            reservedJson = 
            {
                
                selectedTurn {
                    DayOfWeek,
                    Date,
                    StartTime,
                    EndTime,
                    ServiceSupplyId
                },
                reservationTime
    
            }
            reservedJson.selectedTurn.StartTime
            */
            //$.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

            $http({
                method: 'POST',
                url: "/Public/Appointment/retriveIPAForceOnReloadOrExitPage",
                data: JSON.stringify({
                    serviceSupplyId: reservedJson.selectedTurn.ServiceSupplyId,
                    date: reservedJson.selectedTurn.Date,
                    startTime: reservedJson.selectedTurn.StartTime,
                    reservationTime: reservedJson.reservationTime,
                    isSelectedDoctor: true
                })

            }).success(function (data, status, headers, config) {
                if (data.Result == "Success") {
                    $scope.selectedDoctorSelectedTurn = null;
                    $scope.isReservingForSelectedDoctor = false;
                    showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "info");
                    localStorage.removeItem('RAFSD');
                    $timeout.cancel($scope.retriveIpaTimerForSelectedDoctor);
                } else {
                    showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "error");
                }
                //$.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                checkReservedAlready()
                //$.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }

    }



    $scope.checkReservedAlreadyOutside = function () {
        $scope.refreshMyCaptchaImage('imgcaptcha');
        $scope.refreshMyCaptchaImage('imgcaptchaselecteddoctor');
        $scope.myCaptcha = null;
        checkReservedAlready();
    }



    function startTimer(duration, display) {
        var timer = duration, minutes, seconds;
        countDownTimer = setInterval(function () {
            minutes = parseInt(timer / 60, 10)
            seconds = parseInt(timer % 60, 10);

            minutes = minutes < 10 ? "0" + minutes : minutes;
            seconds = seconds < 10 ? "0" + seconds : seconds;

            display.text(minutes + ":" + seconds);

            if (--timer < 0) {
                timer = duration;
            }
        }, 1000);
    }


    var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");

    $scope.analyzePassword = function (value) {
        if (strongRegex.test(value)) {
            $scope.passwordStrength = true;
        } else {
            $scope.passwordStrength = false;
        }
    };

    $scope.clinicsSearched = false;
    $scope.onlygovernmental = false;
    $scope.onlyhostelry = false;


    /// :: ==================================================================
    /// :: Get initial data from server
    /// :: ==================================================================
    function getInitialData() {
        $http({
            method: "GET",
            url: "/Public/Appointment/getInitialData"

        }).success(function (data, status, headers, config) {
            $scope.ExpiredIpaMinutes = data.ExpiredMinutes;
            $scope.ExpiredIpaSeconds = $scope.ExpiredIpaMinutes * 60;
            $scope.ExpiredIpaMiliSeconds = ($scope.ExpiredIpaMinutes * 60) * 1000;
            $scope.PersianDayOfWeekStr = data.PersianDayOfWeekStr;
            $scope.PersianDayOfWeekNum = data.PersianDayOfWeekNum;
            $scope.PersianMonthStr = data.PersianMonthStr;
            $scope.PersianYearNum = data.PersianYearNum;
            $("#Langbox #lang-btn-group #current-date").text($scope.PersianDayOfWeekStr + " " + $scope.PersianDayOfWeekNum + " " + $scope.PersianMonthStr + " " + $scope.PersianYearNum);

            $scope.province = parseInt(data.DefaultProvinceId);
            $scope.GetCities(true, $scope.province, false);
            $scope.city = parseInt(data.DefaultCityId);
            //get cities for clinics section
            $scope.province_clinic = parseInt(data.DefaultProvinceId);
            $scope.GetCities(true, $scope.province, true);
            $scope.city_clinic = parseInt(data.DefaultCityId);
            //نکته: کد شهر و استان ممکن است متفاوت باشند. باید از بانک اطلاعاتی گرفته شوند

            $scope.clinicTypes = data.ClinicTypes;

            $scope.hospitalsCount = data.HospitalsCount;
            $scope.clinicsCount = data.ClinicsCount;
            $scope.polyclinicsCount = data.PolyclinicsCount;
            $scope.usersCount = data.UsersCount;
            $scope.appointsCount = data.AppointsCount;

            $("#app-download .app-link-area a").attr('href', data.AppDownloadLink);

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
            showMessageBox("هەڵە", $scope.message, "error");
        });
    }



    $scope.printDiv = function (divName) {
        var printContents = document.getElementById(divName).innerHTML;
        var popupWin = window.open('', '_blank', 'width=800,height=800');
        popupWin.document.open();
        popupWin.document.write('<DOCTYPE html>' +
            '<html>' +
            '<head>' +
            '<title>ئەوڕۆنۆرە</title>' +
            '<link rel="stylesheet" href="../../Content/website/common/PersianSite.css" />' +
            '<style>' +
            '#print-container{text-align:center; padding: 200px; 150px; 0 200px;}' +
            '#print-content{min-width: 400px; max-width: 400px; min-height:500px; border: 2px solid black; padding:20px;}' +
            '#doctor-print-info{min-width: 100%; min-height:100px; border: 1px solid gray;}' +
            '#patient-print-info{min-width: 100%; min-height:100px; border: 1px solid gray;}' +
            '#tips{min-width: 100%; min-height:100px; border: 1px solid gray;}' +
            '</style>' +
            '</head>' +
            '<body onload="window.print()">' + printContents + '</body>' +
            '</html>');
        popupWin.document.close();
    }

    $scope.wizardLevel = function (level) {
        $.gotoWizardLevel(level);
    }



    /// :: ==================================================================
    /// :: Get Provinces List
    /// :: ==================================================================
    function GetProvinces() {

        $http({
            method: "GET",
            url: "/Public/Home/GetProvinces"

        }).success(function (data, status, headers, config) {
            if (data.ErrorMessage != null) {
                // هەڵەی سمت سرور
                showMessageBox("هەڵە", data.ErrorMessage, "error");
                $scope.provinces = null;
            } else {
                $scope.provinces = data;
            }

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
            showMessageBox("هەڵە", $scope.message, "error");

            $scope.cities = null;

        });
    }
    /// :: ==================================================================


    /// :: ==================================================================
    /// :: Get Cities List
    /// :: ==================================================================
    $scope.GetCities = function (isInit, provinceId, isForClinic) {
        var _provinceId = provinceId;
        if (_provinceId) {
            if (!isInit) {
                $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });
            }

            $http({
                method: "GET",
                url: "/Public/Home/GetCities?provinceId=" + _provinceId
            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    showMessageBox("هەڵە", data.ErrorMessage, "error");
                    $scope.cities = null;
                    $scope.clinicCities = null;
                } else {
                    if (isForClinic) {
                        $scope.clinicCities = data;
                    } else {
                        $scope.cities = data;
                    }
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }
        else {
            $scope.cities = null;
            $.unblockUI();
        }
    }
    /// :: ==================================================================  



    /// :: ==================================================================
    /// :: Get Independent Clinics For City
    /// :: ==================================================================
    $scope.getIndependentClinics = function () {

        $scope.clinicsSearched = true;

        $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });
        $http({
            method: 'GET',
            url: "/Public/Appointment/GetIndependentClinics",
            params: {
                type: $scope.clinic_type,
                name: $scope.clinic_name,
                provinceId: $scope.province_clinic,
                cityId: $scope.city_clinic,
                isGovernmental: $scope.onlygovernmental,
                isHostelry: $scope.onlyhostelry
            }

        }).success(function (data, status, headers, config) {
            if (data.ErrorMessage != null) {
                // هەڵەی سمت سرور
                showMessageBox("هەڵە", data.ErrorMessage, "error");
                $scope.independentClinics = null;

            } else {
                //اگر موردی یافت نشد
                if ($.isEmptyObject(data)) {
                    $scope.clinicsSerachResult = "Null";
                    $scope.independentClinics = null;
                }
                else {
                    $scope.independentClinics = data;
                    $scope.clinicsSerachResult = "noNull";
                }
            }
            $.unblockUI();

            $.unblockUI();

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
            alert(data)
            $.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");
        });
    }
    /// :: ==================================================================


    /// :: ==================================================================
    /// :: Set Selected clinic to scope that can be used in application
    /// :: ==================================================================
    $scope.SetSelectedClinic = function (clinic, isSelected) {

        $scope.readyToPrintFactor = false;

        if (isSelected) {
            $scope.independentClinic = clinic;
            $scope.getClinicPolyclinics();
        }
        else {
            $scope.independentClinic = null;
            $scope.independentClinicPolyclinic = null;
            $scope.independentClinicPolyclinics = null;
            $scope.independentClinicDoctors = null;
        }

        $scope.firstAvailableTurnForSelectedDoctor = null;
        $scope.SetReservationTypeForSelectedDoctor();
        $scope.AgreeToFinalBook = false;
        $scope.bookabletimesForSelectedDoctor = null;
        $scope.selectedDoctorDays = null;
        $scope.selectedDoctorDate = null;

    }
    /// :: ==================================================================




    /// :: Get Independent Clinic Shifts
    /// :: ==================================================================
    $scope.getClinicShifts = function (_clinicId) {
        if (_clinicId) {
            $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });
            $http({
                method: 'POST',
                url: "/Public/Appointment/GetClinicShifts",
                data: JSON.stringify({
                    clinicId: _clinicId
                })

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    showMessageBox("هەڵە", data.ErrorMessage, "error");
                    $scope.ClinicShifts = null;
                } else {
                    console.log(data);
                    $scope.ClinicShifts = data;
                    $("#clinic-shifts-modal").modal();
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                alert(data)
                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }
        else {
            $scope.independentClinicShifts = null;
            $.unblockUI();
        }
    }
    /// :: ==================================================================



    /// :: ==================================================================
    /// :: Set Selected clinic polyclinic to scope that can be used in application
    /// :: ==================================================================
    $scope.SetSelectedClinicPolyclinic = function (clinicPolyclinic, isSelected) {

        $scope.readyToPrintFactor = false;

        if (isSelected) {
            $scope.independentClinicPolyclinic = clinicPolyclinic;
            $scope.getClinicDoctors();
        }
        else {
            $scope.independentClinicPolyclinic = null;
        }

        $scope.firstAvailableTurnForSelectedDoctor = null;
        $scope.SetReservationTypeForSelectedDoctor();
        $scope.AgreeToFinalBook = false;
        $scope.bookabletimesForSelectedDoctor = null;
        $scope.selectedDoctorDays = null;
        $scope.selectedDoctorDate = null;

    }
    /// :: ==================================================================





    /// :: Get Independent Clinic Expertises
    /// :: ==================================================================
    $scope.getClinicPolyclinics = function () {

        var _clinicId = $scope.independentClinic.Id;
        if (_clinicId) {
            $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });
            $http({
                method: 'GET',
                url: "/Public/Appointment/GetClinicPolyclinics",
                params: { clinicId: _clinicId }
            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    showMessageBox("هەڵە", data.ErrorMessage, "error");
                    $scope.independentClinicPolyclinics = null;
                } else {
                    $scope.independentClinicPolyclinics = data;
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                alert(data)
                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }
        else {
            $scope.independentClinicPolyclinics = null;
            $.unblockUI();
        }
    }
    /// :: ==================================================================




    /// :: Get Independent Clinic doctors
    /// :: ==================================================================
    $scope.getClinicDoctors = function () {

        var _clinicId = $scope.independentClinic.Id;
        var _polyclinicId = $scope.independentClinicPolyclinic.Id;
        if (_polyclinicId) {
            $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });
            $http({
                method: 'GET',
                url: "/Public/Appointment/GetClinicPolyclinicDoctors",
                params: {
                    clinicId: _clinicId,
                    polyclinicId: _polyclinicId
                }
            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    showMessageBox("هەڵە", data.ErrorMessage, "error");
                    $scope.independentClinicDoctors = null;
                } else {
                    $scope.independentClinicDoctors = data;
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                alert(data)
                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }
        else {
            $scope.independentClinicDoctors = null;
            $.unblockUI();
        }
    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Get Hospitals List
    /// :: ==================================================================
    function GetHospitals() {

        if ($scope.SelectedTurn == null) {

            //$.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

            $http({
                method: "GET",
                url: "/Public/Appointment/getHospitals"

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    // هەڵەی سمت سرور
                    showMessageBox("هەڵە", data.ErrorMessage, "error");
                    $scope.hospitals = null;
                } else {
                    $scope.hospitals = data;
                }
                //$.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                //$.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");

                $scope.clinics = null;
                $scope.policlinics = null;
                $scope.servicesupplies = null;

            });

            $scope.bookabletimes = null;
            $scope.firstAvailableTurn = null;
            $scope.days = null;
            $scope.date = null;
        } else { //if SelectedTurn != null
            showMessageBox("هشدار", "لطفا ابتدا نوبت انتخاب شده را لغو نمایید", "warning");
        }
    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Get Clinics List
    /// :: ==================================================================
    $scope.GetClinics = function () {

        if ($scope.SelectedTurn == null) {

            var hospitalId = $scope.hospital;
            if (hospitalId) {
                $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

                $http({
                    method: 'POST',
                    url: "/Public/Appointment/getClinics",
                    data: JSON.stringify({
                        hospitalId: hospitalId
                    })

                }).success(function (data, status, headers, config) {
                    if (data.ErrorMessage != null) {
                        showMessageBox("هەڵە", data.ErrorMessage, "error");
                        $scope.clinics = null;
                    } else {
                        $scope.clinics = data;
                    }

                    $.unblockUI();

                }).error(function (data, status, headers, config) {
                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                    $.unblockUI();
                    showMessageBox("هەڵە", $scope.message, "error");

                    $scope.policlinics = null;
                    $scope.servicesupplies = null;

                });
            }
            else {
                $scope.clinics = null;
                $.unblockUI();
            }

            $scope.bookabletimes = null;
            $scope.firstAvailableTurn = null;
            $scope.days = null;
            $scope.date = null;
        } else {
            showMessageBox("warning", "Please cancel selected turn first", "warning");
        }
    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Get PoliClinics List
    /// :: ==================================================================
    $scope.GetPoliClinics = function () {

        if ($scope.SelectedTurn == null) {
            var clinicId = $scope.clinic;
            if (clinicId) {
                $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });


                $http({
                    method: 'POST',
                    url: "/Public/Appointment/getClinicMessage",
                    data: JSON.stringify({
                        clinicId: clinicId
                    })

                }).success(function (data, status, headers, config) {
                    if (data.ErrorMessage != null) {
                    } else {
                        if (data.length > 0) {
                            $scope.clinicMessage = data
                            $scope.clinicMessageShow = true
                        }
                        else
                            $scope.clinicMessageShow = false
                    }

                })

                $http({
                    method: 'POST',
                    url: "/Public/Appointment/getPoliClinics",
                    data: JSON.stringify({
                        clinicId: clinicId
                    })

                }).success(function (data, status, headers, config) {
                    if (data.ErrorMessage != null) {
                        showMessageBox("هەڵە", data.ErrorMessage, "error");
                        $scope.policlinics = null;
                    } else {
                        $scope.policlinics = data;
                    }

                    $.unblockUI();

                }).error(function (data, status, headers, config) {
                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                    $.unblockUI();
                    showMessageBox("هەڵە", $scope.message, "error");

                    $scope.servicesupplies = null;
                });
            }
            else {
                $scope.policlinics = null;
                $.unblockUI();
            }

            $scope.bookabletimes = null;
            $scope.SelectedTurn = null;
            $scope.firstAvailableTurn = null;
            $scope.days = null;
            $scope.date = null;
        } else {
            showMessageBox("warning", "Please cancel selected turn first", "warning");
        }

    }
    /// :: ==================================================================



    /// :: ==================================================================
    /// :: Get PoliClinic Health Services List
    /// :: ==================================================================
    $scope.GetHealthServices = function () {

        if ($scope.SelectedTurn == null) {
            var poliClinicId = $scope.policlinic;
            if (poliClinicId) {
                $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

                $http({
                    method: 'POST',
                    url: "/Public/Appointment/getPolyclinicHealthServices",
                    data: JSON.stringify({
                        polyclinicId: poliClinicId
                    })

                }).success(function (data, status, headers, config) {
                    if (data.ErrorMessage != null) {
                        showMessageBox("هەڵە", data.ErrorMessage, "error");
                        $scope.healthservices = null;
                    } else {
                        $scope.healthservices = data;
                    }

                    $.unblockUI();

                }).error(function (data, status, headers, config) {
                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                    $.unblockUI();
                    showMessageBox("هەڵە", $scope.message, "error");
                });
            }
            else {
                $scope.healthservices = null;
                $.unblockUI();
            }

            $scope.bookabletimes = null;
            $scope.SelectedTurn = null;
            $scope.date = null;
        } else {
            showMessageBox("warning", "Please cancel selected turn first", "warning");
        }

    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Get ServiceSupplies(Doctors) List
    /// :: ==================================================================
    $scope.GetServiceSupplies = function () {

        if ($scope.SelectedTurn == null) {
            var poliClinicId = $scope.policlinic;
            var polyclinicHealthServiceId = $scope.healthservice;
            if (poliClinicId) {
                $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

                $http({
                    method: 'POST',
                    url: "/Public/Appointment/getServiceSupplies",
                    data: JSON.stringify({
                        poliClinicId: poliClinicId,
                        polyclinicHealthServiceId: polyclinicHealthServiceId
                    })

                }).success(function (data, status, headers, config) {
                    if (data.ErrorMessage != null) {
                        showMessageBox("هەڵە", data.ErrorMessage, "error");
                        $scope.servicesupplies = null;
                    } else {
                        $scope.servicesupplies = data;
                    }

                    $.unblockUI();

                }).error(function (data, status, headers, config) {
                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                    $.unblockUI();
                    showMessageBox("هەڵە", $scope.message, "error");
                });
            }
            else {
                $scope.servicesupplies = null;
                $.unblockUI();
            }

            $scope.bookabletimes = null;
            $scope.SelectedTurn = null;
            $scope.date = null;
        } else {
            showMessageBox("warning", "Please cancel selected turn first", "warning");
        }

    }
    /// :: ==================================================================




    $scope.SetReservationType = function () {

        $scope.days = null;
        $scope.date = null;

        var _serviceSupplyId = $scope.servicesupply;

        var serviceSupply = null;

        angular.forEach($scope.servicesupplies, function (value, key) {
            if (value.serviceSupplyId == _serviceSupplyId) {
                serviceSupply = value;
                return;
            }

        });

        if (serviceSupply && serviceSupply != null) {
            switch (serviceSupply.reservationType) {
                case "Selective":
                    $scope.InitializeDatePicker();
                    $scope.firstAvailableTurn = null;
                    break;
                case "Sequentially":
                    $scope.GetFirstAvailableTurn(false, false);// False: Not Updating ,  False: Not Updating Force
                    $scope.days = null;
                    break;
                default:
                    $scope.GetFirstAvailableTurn(false, false);
                    $scope.days = null;
            }
        }

        $scope.GetDoctorInfo(_serviceSupplyId);

    }



    /// :: ==================================================================
    /// :: Get Reservable Days For Datepicker
    /// :: ==================================================================
    $scope.InitializeDatePicker = function () {

        var serviceSupplyId = $scope.servicesupply;
        var polyclinicHealthServiceId = $scope.healthservice;
        if (serviceSupplyId) {
            $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

            $http({
                method: 'POST',
                url: "/Public/Appointment/getDatePickerDays",
                data: JSON.stringify({
                    serviceSupplyId: serviceSupplyId,
                    polyclinicHealthServiceId: polyclinicHealthServiceId
                })

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    if (data.IsForNoAvailableTurns == true) {
                        $scope.ErrorTitle = data.ErrorTitle;
                        $scope.ErrorMessage = data.ErrorMessage;
                        $("#no-turn-modal").modal({ backdrop: 'static', keyboard: false });
                    } else {
                        showMessageBox("هەڵە", data.ErrorMessage, "error");
                    }

                    $scope.days = null;
                } else {
                    $scope.days = data;

                    $("#datepicker0").datepicker("destroy");

                    $("#datepicker0").val("");

                    //Initialize DatePicker Control
                    $("#datepicker0").datepicker({
                        minDate: $scope.days.MinDate,
                        maxDate: "+" + $scope.days.MaxDate + "D",
                        showButtonPanel: true,
                        showOtherMonths: true,
                        selectOtherMonths: true,
                        isRTL: true,
                        dateFormat: "yy/m/d"
                    });
                    $("#datepicker0btn").click(function (event) {
                        event.preventDefault();
                        $("#datepicker0").focus();
                    })

                    //-------------------------------------
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });

        } else {
            $scope.days = null;
            $.unblockUI();
        }

        $scope.bookabletimes = null;
        $scope.SelectedTurn = null;
    }
    /// :: ==================================================================




    $scope.GetFirstAvailableTurn = function (IsUpdating, IsForce) {

        var oldFirstavailableTurn = null;
        if (IsUpdating && !IsForce) {
            oldFirstavailableTurn = $scope.SelectedTurn;
        }

        var serviceSupplyId = $scope.servicesupply;
        var polyclinicHealthServiceId = $scope.healthservice;

        if (serviceSupplyId) {
            if (!IsUpdating) {
                $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });
            }

            $http({
                method: 'POST',
                url: "/Public/Appointment/getFirstAvailableTurn",
                data: JSON.stringify({
                    serviceSupplyId: serviceSupplyId,
                    polyclinicHealthServiceId: polyclinicHealthServiceId
                })

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    if (!IsUpdating) {
                        if (data.IsForNoAvailableTurns == true) {
                            $scope.ErrorTitle = data.ErrorTitle;
                            $scope.ErrorMessage = data.ErrorMessage;
                            $("#no-turn-modal").modal({ backdrop: 'static', keyboard: false });
                        } else {
                            showMessageBox("هەڵە", data.ErrorMessage, "error");
                        }
                    }

                    $scope.firstAvailableTurn = null;

                } else {

                    $scope.firstAvailableTurn = data;

                    if (!IsUpdating) {
                        if (data.PrerequisiteName != "") {
                            $scope.PrerequisiteName = data.PrerequisiteName;
                            $scope.PrerequisiteBookableTime = null;
                            $("#prerequisite-modal").modal({ backdrop: 'static', keyboard: false });
                        }
                    }

                    if (IsUpdating) {
                        if (oldFirstavailableTurn != null) {
                            if (angular.equals(oldFirstavailableTurn, $scope.firstAvailableTurn)) {
                                $scope.SelectedTurn = null;
                                if (!IsForce) {
                                    showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                                    $.gotoWizardLevel(1);
                                    localStorage.removeItem('RA');
                                }
                            } else {

                                // می خواهیم بدانیم نوبت قفل شده هنوز هم قفل است یا بعد از مدت زمان معین توسط سرور از حالت قفل خارج شده است
                                $http({
                                    method: 'POST',
                                    url: "/Public/Appointment/isInProgressNow",
                                    data: JSON.stringify({
                                        serviceSupplyId: oldFirstavailableTurn.ServiceSupplyId, date: oldFirstavailableTurn.Date, startTime: oldFirstavailableTurn.StartTime
                                    })

                                }).success(function (data, status, headers, config) {
                                    if (data.Result == "Success" && data.Message == "NO") {
                                        $scope.SelectedTurn = null;
                                        if (!IsForce) {
                                            showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                                            $.gotoWizardLevel(1);
                                            localStorage.removeItem('RA');
                                        }
                                    } else {

                                    }

                                }).error(function (data, status, headers, config) {
                                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                                });
                            }
                        }
                    }
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });

        } else {
            $scope.firstAvailableTurn = null;
            $.unblockUI();
        }
    }


    $scope.acceptPrerequisite = function () {
        $scope.prerequisiteAccepted = true;

        if ($scope.PrerequisiteBookableTime != null) {
            $scope.ReserveAppointment($scope.PrerequisiteBookableTime);
        }
    }

    $scope.cancelPrerequisite = function () {
        $scope.SelectedTurn = null;
        $scope.hospital = null;
        $scope.clinics = null;
        $scope.policlinics = null;
        $scope.servicesupplies = null;
        $scope.firstAvailableTurn = null;
        $scope.healthservices = null;
        $scope.prerequisiteAccepted = false
        $scope.PrerequisiteBookableTime = null;
        $.gotoWizardLevel(1);
    }



    /// :: ==================================================================
    /// :: Get Bookable Times List
    /// :: ==================================================================
    /// :: IsUpdating
    /// این پارامتر نشان می دهد که آیا لیست نوبت ها برای اولین بار ایجاد می شود و یا اینکه با دستور سرور تازه سازی می شود
    /// هنگامی که تازه سازی صورت می گیرد بهتر است بصورت نا محسوس باشد تا کاربر متوجه این کار نشود
    $scope.GetBookableTimes = function (IsUpdating) {

        // برای اینکه بررسی کنیم که آیا نوبتی بعد از بازه زمانی خودکار باز میگردد نوبت انتخاب شده این کلاینت است یا کلاینتهای دیگر
        var tmpOldBookableTimes = null;

        if (IsUpdating) {
            tmpOldBookableTimes = $scope.bookabletimes;
        }

        var date = $scope.date;
        if (date == null || date == "") {

            if (!IsUpdating) {
                showMessageBox("هەڵە", 'تکایە بەروارێک دیاری بکەن', "error");
            }

        } else {
            var serviceSupplyId = $scope.servicesupply;
            if (serviceSupplyId) {
                if (!IsUpdating) { //اگر برای اولین بار لیست نوبت ها ایجاد شود بهتر است سطح پیشرفت کار به کاربر نشان داده شود
                    $.blockUI({
                        message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
                    });
                }

                $http({
                    method: 'POST',
                    url: "/Public/Appointment/getBookableTimes",
                    data: JSON.stringify({
                        serviceSupplyId: serviceSupplyId,
                        date: date,
                        polyclinicHealthServiceId: $scope.healthservice
                    })

                }).success(function (data, status, headers, config) {
                    if (data.ErrorMessage != null) {
                        if (!IsUpdating) {
                            showMessageBox("هەڵە", data.ErrorMessage, "error");
                        }
                        $scope.bookabletimes = null;
                    } else {
                        $scope.bookabletimes = data;

                        if (IsUpdating) {
                            // if SelectedTurn not exists in the oldBookableTimes before update
                            // and now exist in the newly updated bookable times
                            // then SelectedTurn = null
                            var existInOldBookableTimes = false;
                            var existInUpdatedBookableTimes = false

                            if ($scope.SelectedTurn != null) {

                                if (tmpOldBookableTimes != null) {

                                    angular.forEach(tmpOldBookableTimes, function (value, key) {
                                        if (value.DayOfWeek == $scope.SelectedTurn.DayOfWeek &&
                                            value.Date == $scope.SelectedTurn.Date &&
                                            value.StartTime == $scope.SelectedTurn.StartTime &&
                                            value.EndTime == $scope.SelectedTurn.EndTime &&
                                            value.ServiceSupplyId == $scope.SelectedTurn.ServiceSupplyId) {
                                            existInOldBookableTimes = true;
                                            return;
                                        }
                                    });
                                }

                                if ($scope.bookabletimes != null) {
                                    angular.forEach($scope.bookabletimes, function (value, key) {
                                        if (value.DayOfWeek == $scope.SelectedTurn.DayOfWeek &&
                                            value.Date == $scope.SelectedTurn.Date &&
                                            value.StartTime == $scope.SelectedTurn.StartTime &&
                                            value.EndTime == $scope.SelectedTurn.EndTime &&
                                            value.ServiceSupplyId == $scope.SelectedTurn.ServiceSupplyId) {
                                            existInUpdatedBookableTimes = true;
                                            return;
                                        }

                                    });
                                }

                            }

                            if (!existInOldBookableTimes && existInUpdatedBookableTimes) {
                                // چون نوبت انتخاب شده بعد از مدت زمان مشخص بصورت اتوماتیک بازگشته است مقدار انتخاب شده را خالی می کنیم
                                $scope.SelectedTurn = null;
                                showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                                $.gotoWizardLevel(1);
                                localStorage.removeItem('RA');
                            }
                        }
                    }

                    $.unblockUI();

                }).error(function (data, status, headers, config) {
                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                    $.unblockUI();
                    if (!IsUpdating) {
                        showMessageBox("هەڵە", $scope.message, "error");
                    }

                });
            }
            else {
                $scope.bookabletimes = null;
                $.unblockUI();
            }

        }

    }
    /// :: ==================================================================





    /// :: ==================================================================
    /// :: Reserve Appointment Temporary
    /// :: ==================================================================
    $scope.ReserveAppointment = function (bookabletime) {

        if (bookabletime.PrerequisiteName != "") {
            if (!$scope.prerequisiteAccepted) {
                $scope.PrerequisiteName = bookabletime.PrerequisiteName;
                $scope.PrerequisiteBookableTime = bookabletime;
                if (!$scope.isReserving) {
                    $("#prerequisite-modal").modal({ backdrop: 'static', keyboard: false });
                }
            }
        }
        if ((bookabletime.PrerequisiteName != "" && $scope.prerequisiteAccepted) || bookabletime.PrerequisiteName == "") {

            $scope.PrerequisiteBookableTime = null;

            $scope.isReserving = true;

            $.blockUI({
                message: '<i class="fa fa-cog fa-spin fa-3x fa-fw"></i>'
            });

            /*if (!appointmentsService.isConnected()) {
                appointmentsService.connect();
            }*/

            $http({
                method: 'POST',
                url: "/Public/Appointment/reserveAppointment",
                data: JSON.stringify({
                    mobile: $scope.mobile,
                    serviceSupplyId: bookabletime.ServiceSupplyId,
                    date: bookabletime.Date,
                    startTime: bookabletime.StartTime,
                    endTime: bookabletime.EndTime,
                    isSelectedDoctor: false,
                    polyclinicHealthServiceId: $scope.healthservice,
                    myCaptcha: $scope.myCaptcha
                }),
                headers: {
                    'RequestVerificationToken': $scope.antiForgeryToken
                }

            }).success(function (data, status, headers, config) {
                if (data.Result == "Success") {

                    angular.element('#hospitalsTimer').text("");
                    clearTimeout(countDownTimer);
                    startTimer($scope.ExpiredIpaSeconds, $('#hospitalsTimer'));

                    //$scope.GetDoctorInfo(bookabletime.ServiceSupplyId);
                    $scope.GetHospitalInfo(bookabletime.ServiceSupplyId);
                    $scope.SelectedTurn = bookabletime;
                    $scope.isReserving = false;
                    $scope.ReservationTime = data.ReturnedData;
                    $.unblockUI();

                    /*try {
                        //Notify other clients that appointment reserved
                        appointmentsService.reserveAppointment();
                    } catch (e) {

                    }*/

                    //----------------------------------
                    $scope.ReservedAppointment = {
                        hospital: $scope.hospital,
                        clinic: $scope.clinic,
                        policlinic: $scope.policlinic,
                        selectedTurn: bookabletime,
                        reservationTime: $scope.ReservationTime,
                        prePaymentAmount: data.PaymentStatus.PrePaymentAmount,
                        appointmentAmount: data.PaymentStatus.AppointmentAmount,
                        totalPrice: data.PaymentStatus.PrePaymentAmount + data.PaymentStatus.AppointmentAmount
                    };
                    localStorage.setItem("RA", angular.toJson($scope.ReservedAppointment));
                    //Timer to retrive ipa localy if signalr don't work                
                    $scope.retriveIpaTimer = $timeout(function () {
                        var reservedAlready = localStorage.getItem("RA");
                        if (reservedAlready != null) {
                            //var reservedJson = JSON.parse(reservedAlready);
                            $scope.RetriveInprogressAppointment();
                            $scope.SelectedTurn = null;
                            $scope.isReserving = false;
                            showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                            $.gotoWizardLevel(1);
                            localStorage.removeItem('RA');
                            $scope.UpdateAppointmentsList();
                        }
                    }, $scope.ExpiredIpaMiliSeconds);
                    //----------------------------------

                } else {
                    showMessageBox("هەڵە", data.Message, "error");
                    showMessageBox("هەڵە", "لە کاتی تۆمار کردنی نۆرە هەڵەییک رووی دا", "error");
                    $scope.SelectedTurn = null;
                    $scope.isReserving = false;
                    $scope.ReservationTime = null;
                    $.unblockUI();
                    $scope.UpdateAppointmentsList();
                }
                $.unblockUI();

            }).error(function (data, status, headers, config) {
                //500 Internal Server Error
                if (status == 500) {
                    var err500 = "Security Token Expired";
                    showMessageBox("توجه", err500, "warning");
                } else {
                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                    showMessageBox("هەڵە", $scope.message, "error");
                }
                $scope.SelectedTurn = null;
                $scope.isReserving = false;
                $scope.ReservationTime = null;
                $.unblockUI();
            });
        }
    }
    /// :: ==================================================================




    $scope.RetriveInprogressAppointment = function () {
        var ipa = $scope.SelectedTurn;

        if (ipa && ipa != null) {
            $.blockUI({
                message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
            });

            $http({
                method: 'POST',
                url: "/Public/Appointment/retriveInprogressAppointmentForce",
                data: JSON.stringify({
                    serviceSupplyId: ipa.ServiceSupplyId, date: ipa.Date, startTime: ipa.StartTime, isSelectedDoctor: false
                })

            }).success(function (data, status, headers, config) {
                if (data.Result == "Success") {
                    $scope.SelectedTurn = null;
                    $scope.isReserving = false;
                    $scope.prerequisiteAccepted = false;
                    $scope.PrerequisiteBookableTime = null;
                    showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "info");
                    localStorage.removeItem('RA');
                    $timeout.cancel($scope.retriveIpaTimer);
                    $.gotoWizardLevel(3);
                    $scope.UpdateAppointmentsList();
                } else {
                    showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "error");
                }
                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }
    }






    $scope.GetInsurances = function () {
        $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

        $http({
            method: "GET",
            url: "/Public/Appointment/getInsurances"

        }).success(function (data, status, headers, config) {
            if (data.ErrorMessage != null) {
                showMessageBox("هەڵە", data.ErrorMessage, "error");
                $scope.insurances = null;
            } else {
                $scope.insurances = data;
            }
            $.unblockUI();

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

            $.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");

        });
    }






    $scope.GetDoctorInfo = function (serviceSupplyId) {

        if (serviceSupplyId) {

            $http({
                method: 'POST',
                url: "/Public/Appointment/GetDoctorInfo",
                data: JSON.stringify({
                    serviceSupplyId: serviceSupplyId
                })

            }).success(function (data, status, headers, config) {
                $scope.doctorInfos = data;

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });

        }


    }





    $scope.GetHospitalInfo = function (serviceSupplyId) {

        if (serviceSupplyId) {
            $http({
                method: 'POST',
                url: "/Public/Appointment/GetHospitalInfo",
                data: JSON.stringify({
                    serviceSupplyId: serviceSupplyId
                })

            }).success(function (data, status, headers, config) {
                $scope.hospitalInfos = data;

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }
    }




    $scope.checkMobile = function (mobile) {
        //extract only numbers from string (because of mask in some mobile phones the string will be like this: 3--_------_- and this make error on some devices
        /*var tmpStr = mobile.match(/\d+/g) ? mobile.match(/\d+/g) : [];*/
        //after extract numbers we have a string like this: 111,111111,1. then replace ',' with '-' because in server side we work on '-' to extract the right national code
        /*var _mobile = tmpStr.toString().replace(new RegExp(",", "g"), '-');*/

        _mobile = mobile;

        if (_mobile.length >= 10) {

            $.blockUI({
                message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
            });

            $http({
                method: 'POST',
                url: "/Public/Appointment/checkMobile",
                data: JSON.stringify({
                    mobile: _mobile
                })

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage == null) {
                    if (data.ExistAlready == true) {
                        $scope.ExistUser = true;
                        $scope.wrongMobile = false;
                        $scope.firstName = data.FirstName;
                        $scope.secondName = data.SecondName;
                        $scope.thirdName = data.ThirdName;
                        $scope.gender = data.Gender;
                        $scope.email = data.Email;
                    } else {
                        $scope.ExistUser = false;
                        $scope.wrongMobile = false;
                        $scope.firstName = null;
                        $scope.secondName = null;
                        $scope.thirdName = null;
                        $scope.gender = null;
                        $scope.email = null;
                        $scope.Password = null;
                        $scope.confirmPassword = null;
                    }
                } else {
                    showMessageBox("هەڵە", data.ErrorMessage, "error");
                    $scope.wrongMobile = true;
                    $scope.ExistUser = false;
                    $scope.firstName = null;
                    $scope.secondName = null;
                    $scope.thirdName = null;
                    $scope.gender = null;
                    $scope.email = null;
                    $scope.Password = null;
                    $scope.confirmPassword = null;
                }
                $.unblockUI();
            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        } else {
            $scope.wrongMobile = true;
            $scope.ExistUser = false;
            $scope.firstName = null;
            $scope.secondName = null;
            $scope.thirdName = null;
            $scope.gender = null;
            $scope.email = null;
            $scope.Password = null;
            $scope.confirmPassword = null;
        }
    }




    /// :: ==================================================================
    /// :: Get Recaptcha Response (GOOGLE CAPTCHA)
    /// :: ==================================================================
    $scope.getRecaptchaResponse = function () {
        $.blockUI({ message: '<i class="fa fa-cog fa-spin fa-3x fa-fw"></i>' });
        //$scope.captcharesponse = grecaptcha.getResponse();
        $.unblockUI();
    }





    /// :: ==================================================================
    /// :: Set Recaptcha Response into scope (GOOGLE CAPTCHA)
    /// :: ==================================================================
    $scope.setRecaptchaResponseIntoScope = function (response) {
        //$scope.captcharesponse = response;
    }


    $scope.refreshMyCaptchaImage = function (img) {
        $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

        $http({
            method: "GET",
            url: "/Captcha/CaptchaImage"

        }).success(function (data, status, headers, config) {
            //Refresh captcha image
            d = new Date();
            $("#" + img).attr("src", "/Captcha/CaptchaImage?" + d.getTime());
            $.unblockUI();

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

            $.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");

        });
    }


    //$scope.checkcaptcha = function () {
    //    return false;
    //}

    //$http({
    //    method: 'GET',
    //    url: "http://blog.banobat.ir/wp-json/wp/v2/posts?categories=1",

    //}).success(function (data, status, headers, config) {
    //    $scope.ads = '<div class="owl- carousel topads" dir="ltr">';
    //    for (var a in data) {
    //        $scope.ads += '<div><img class="owl-lazy" data-src="' + a.better_featured_image.media_details.medium_large.source_url + '" alt= "دکتر پریسا دارابی" /></div >';
    //    }
    //    $scope.ads += "</div>";
    //    console.log($scope.ads)

    //}).error(function (data, status, headers, config) {

    //});

    /// :: ==================================================================
    /// :: Final Booking Appointment
    /// :: ==================================================================
    $scope.FinalBookAppointment = function () {

        $.blockUI({ message: '<i class="fa fa-cog fa-spin fa-3x fa-fw"></i>' });

        $http({
            method: 'POST',
            url: "/Public/Appointment/finalBookAppointment",
            data: JSON.stringify({
                serviceSupplyId: $scope.SelectedTurn.ServiceSupplyId,
                date: $scope.SelectedTurn.Date,
                startTime: $scope.SelectedTurn.StartTime,
                endTime: $scope.SelectedTurn.EndTime,
                FirstName: $scope.firstName,
                SecondName: $scope.secondName,
                ThirdName: $scope.thirdName,
                Mobile: $scope.mobile,
                Gender: $scope.gender == "Male" ? 0 : 1,
                pEmail: $scope.email,
                pInsuranceId: $scope.insuranceId,
                pInsuranceNumber: $scope.insuranceNumber,
                existUser: $scope.ExistUser,
                reservationTime: $scope.ReservationTime,
                //captcharesponse: $scope.captcharesponse,
                paymentStatus: $scope.ReservedAppointment.totalPrice <= 0 ? 0 : 2,
                polyclinicHealthServiceId: $scope.healthservice,
                myCaptcha: $scope.myCaptcha
            }),
            headers: {
                'RequestVerificationToken': $scope.antiForgeryToken
            }

        }).success(function (data, status, headers, config) {
            //$.unblockUI();
            if (data.Result == "Success") {
                if (data.AppointmentId != -1) {
                    if ($scope.ReservedAppointment.totalPrice > 0) {
                        var tId = data.AppointmentId;
                        var price = $scope.ReservedAppointment.totalPrice;
                        $scope.ReservedAppointment = null;
                        var url = "/public/payment?turnId=" + tId + "&price=" + price + "&fromMobile=false";
                        $.blockUI({
                            message: '<i class="fa fa-cog fa-spin fa-3x fa-fw"></i><p>Connecting to payment form</p>'
                        });
                        $window.location.href = url;
                    } else {
                        $scope.QueueNumber = data.QueueNumber;
                        $scope.FinalBookMessage = data.Message;
                        $.gotoWizardLevel(5);
                    }
                }

                //:: Empty all variables
                $scope.SelectedTurn = null;
                $scope.hospital = null;
                $scope.clinics = null;
                $scope.policlinics = null;
                $scope.servicesupplies = null;
                $scope.firstAvailableTurn = null;
                $scope.healthservices = null;
                $timeout.cancel($scope.retriveIpaTimer);
                /*try {
                    appointmentsService.reserveAppointment();
                } catch (e) {

                }*/
                localStorage.removeItem('RA');

                $scope.prerequisiteAccepted = false
                $scope.PrerequisiteBookableTime = null;

                //Clear User Entered Data
                $scope.wrongMobile = true;
                $scope.ExistUser = false;
                $scope.mobile = null;
                $scope.firstName = null;
                $scope.lastName = null;
                $scope.mobilePhone = null;
                $scope.gender = null;
                $scope.email = null;
                $scope.insurances = null;
                $scope.insuranceNumber = null;

                $scope.refreshMyCaptchaImage('imgcaptcha');
                $scope.refreshMyCaptchaImage('imgcaptchaselecteddoctor');
                $scope.myCaptcha = null;

            } else {
                showMessageBox("رزرڤی نۆرە", data.Message, "error");
                $.unblockUI();
            }

            //grecaptcha.reset(captchaWidget1);
            //$scope.captcharesponse = null;

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

            $.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");
            //grecaptcha.reset(captchaWidget1);
            //$scope.captcharesponse = null;
        });

    }
    /// :: ==================================================================



    $scope.AgreeToContinue = function (value) {
        $scope.continue = value;
    }


    $scope.setAgreeToFinalBook = function (value) {
        $scope.AgreeToFinalBook = value;
    }






    ///in this method we update list of available appointments in normal mode with showing loader to user.
    $scope.UpdateAppointmentsList = function () {
        var _serviceSupplyId = $scope.servicesupply;

        var serviceSupply = null;

        angular.forEach($scope.servicesupplies, function (value, key) {
            if (value.serviceSupplyId == _serviceSupplyId) {
                serviceSupply = value;
                return;
            }

        });

        if (serviceSupply && serviceSupply != null) {
            switch (serviceSupply.reservationType) {
                case "Selective":
                    $scope.GetBookableTimes(false);
                    break;
                case "Sequentially":
                    $scope.GetFirstAvailableTurn(false, false);
                    break;
                default:
                    $scope.GetBookableTimes(false);
            }
        }
    }




    ////////////////////////////////////////////////////////////////
    /// :: SignalR Realtiming Methods
    ////////////////////////////////////////////////////////////////
    $scope.$on("appointmentReserved", function (event) {

        var _serviceSupplyId = $scope.servicesupply;

        var serviceSupply = null;

        angular.forEach($scope.servicesupplies, function (value, key) {
            if (value.serviceSupplyId == _serviceSupplyId) {
                serviceSupply = value;
                return;
            }

        });

        if (serviceSupply && serviceSupply != null) {
            switch (serviceSupply.reservationType) {
                case "Selective":
                    $scope.GetBookableTimes(true);
                    break;
                case "Sequentially":
                    $scope.GetFirstAvailableTurn(true, false);
                    break;
                default:
                    $scope.GetBookableTimes(true);
            }
        }

        $scope.$apply();
    })



    $scope.$on("appointmentRecovered", function (event) {

        var _serviceSupplyId = $scope.servicesupply;

        var serviceSupply = null;

        angular.forEach($scope.servicesupplies, function (value, key) {
            if (value.serviceSupplyId == _serviceSupplyId) {
                serviceSupply = value;
                return;
            }

        });

        if (serviceSupply && serviceSupply != null) {
            switch (serviceSupply.reservationType) {
                case "Selective":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimes(true);
                    break;
                case "Sequentially":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetFirstAvailableTurn(true, false);
                    break;
                default:
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimes(true);
            }
        }

        $scope.$apply();
    })


    $scope.$on("appointmentRecoveredForce", function (event) {

        var _serviceSupplyId = $scope.servicesupply;

        var serviceSupply = null;

        angular.forEach($scope.servicesupplies, function (value, key) {
            if (value.serviceSupplyId == _serviceSupplyId) {
                serviceSupply = value;
                return;
            }

        });

        if (serviceSupply && serviceSupply != null) {
            switch (serviceSupply.reservationType) {
                case "Selective":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimes(true);
                    break;
                case "Sequentially":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetFirstAvailableTurn(true, true);
                    break;
                default:
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimes(true);
            }
        }

        $scope.$apply();
    })
    /////////////////////////////////////////////////////////////////        





    function showMessageBox(_title, _message, _type) {
        $.msgBox({
            title: _title,
            content: _message,
            type: _type,
            modal: true
        });
    }



    function initializeBlockUI() {
        //Styling loader 
        $.blockUI.defaults.css = {
            padding: 0,
            margin: 0,
            width: '0px%',
            top: '40%',
            left: '50%',
            textAlign: 'center',
            color: '#000',
            border: 'none',
            backgroundColor: 'transparent',
            cursor: 'wait',
            'z-index': 100000
        }; // I can remove this stament and change this defaults in native blockUI file
    }



    ////////////////////////////////////////////////////////////////
    /// :: Show an alert before refresh page
    ////////////////////////////////////////////////////////////////
    //$scope.onExit = function () {
    //    return "Don't reload page...";
    //};
    //$window.onbeforeunload = $scope.onExit;
    ////////////////////////////////////////////////////////////////






    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\\

    /// :: ==================================================================
    /// :: Get Expertises List
    /// :: ==================================================================
    $scope.GetExpertises = function () {

        $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw" style="z-index:1051;"></i>' });

        $http({
            method: "GET",
            url: "/Public/Appointment/getExpertises"

        }).success(function (data, status, headers, config) {
            if (data.ErrorMessage != null) {
                // هەڵەی سمت سرور
                showMessageBox("هەڵە", data.ErrorMessage, "error");
                $scope.expertises = null;
            } else {
                $scope.expertises = data;
            }
            $.unblockUI();

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

            $.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");

        });
    }
    /// :: ================================================================== 



    /// :: ==================================================================
    /// :: Get New Expertises List
    /// :: ==================================================================
    function GetNewExpertises() {

        $http({
            method: "GET",
            url: "/Public/Appointment/getNewExpertises"

        }).success(function (data, status, headers, config) {
            if (data.ErrorMessage != null) {
                // هەڵەی سمت سرور
                showMessageBox("هەڵە", data.ErrorMessage, "error");
                $scope.newExpertises = null;
            } else {
                $scope.newExpertises = data;

                $scope.expertisesCount = 0;
                angular.forEach(data, function (value, key) {
                    $scope.expertisesCount += Object.keys(value.Expertises).length;
                });
            }

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
            showMessageBox("هەڵە", $scope.message, "error");

        });
    }
    /// :: ================================================================== 




    $scope.setSelectedExpertiseCategory = function () {
        $scope.selectedExpertiseCategoriesIdArray = [];
        angular.forEach($scope.newExpertises, function (category) {
            if (!!category.ExpertiseCategorySelected) {
                $scope.selectedExpertiseCategoriesIdArray.push(category.ExpertiseCategoryId);
            }
        });

        $scope.selectedExpertiseCategoriesCounts = $scope.selectedExpertiseCategoriesIdArray.length;

        //Clear selected expertises
        $scope.selectedExpertisesIdArray = [];
        $scope.selectedExpertisesCounts = 0;
        angular.forEach($scope.newExpertises, function (value, key) {
            angular.forEach(value.Expertises, function (expertise) {
                if (expertise.Selected) {
                    expertise.Selected = false;
                }
            });
        });


        $scope.SearchDoctors();
    }



    $scope.setSelectedExpertises = function () {
        $scope.selectedExpertisesIdArray = [];
        angular.forEach($scope.newExpertises, function (value, key) {
            angular.forEach(value.Expertises, function (expertise) {
                if (!!expertise.Selected) {
                    $scope.selectedExpertisesIdArray.push(expertise.Id);
                }
            });
        });

        $scope.selectedExpertisesCounts = $scope.selectedExpertisesIdArray.length;

        //Clear selected expertise categories
        $scope.selectedExpertiseCategoriesIdArray = [];
        $scope.selectedExpertiseCategoriesCounts = 0;
        angular.forEach($scope.newExpertises, function (category) {
            if (category.ExpertiseCategorySelected) {
                category.ExpertiseCategorySelected = false;
            }
        });

        $scope.SearchDoctors();
    }



    $scope.scientificCategories = [
        {
            Name: "General"
        },
        { Name: "Specialist" },
        {
            Name: "Ph.D"
        }
    ];




    /// :: ==================================================================
    /// :: Serach Doctors for city by selected filters
    /// :: ==================================================================
    $scope.SearchDoctors = function () {
        $.blockUI({ message: '<i class="fa fa-circle-o-notch fa-spin fa-3x fa-fw" style="color: orange;z-index:1051;"></i>' });

        $http({
            method: 'POST',
            url: "/Public/Appointment/searchDoctors",
            data: JSON.stringify({
                doctorName: $scope.searchDoctorName,
                provinceId: $scope.province,
                cityId: $scope.city,
                onlyhaveturn: $scope.onlyhaveturn,
                expertiseCategories: $scope.selectedExpertiseCategoriesIdArray,
                expertises: $scope.selectedExpertisesIdArray
            })
        }).success(function (data, status, headers, config) {
            if (data.ErrorMessage != null) {
                // هەڵەی سمت سرور
                showMessageBox("هەڵە", data.ErrorMessage, "error");
                $scope.foundedDoctors = null;

            } else {
                //اگر موردی یافت نشد
                if ($.isEmptyObject(data)) {
                    $scope.serachResult = "Null";
                    $scope.foundedDoctors = null;
                }
                else {
                    $scope.foundedDoctors = data;
                    $scope.serachResult = "noNull";
                }
            }
            $.unblockUI();

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

            $.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");
        });

    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Apply Only Have Turn to founded doctors if search result != null
    /// :: ==================================================================
    $scope.applyHaveTurnFilter = function () {
        if ($scope.foundedDoctors || $scope.serachResult == "Null" && ($scope.city || $scope.expertise || $scope.scientificcategory)) {
            $scope.SearchDoctors();
        }
    }
    /// :: ==================================================================





    /// :: ==================================================================
    /// :: Set Selected doctor to scope that can be used in application
    /// :: ==================================================================
    $scope.SetSelectedDoctor = function (doctor, isReserving) {

        $scope.readyToPrintFactor = false;
        $scope.personalDataCompleted = false;
        $scope.turnSelected = false;
        $scope.selectedDoctorSelectedTurn = null;

        $scope.selectedDoctor = doctor;

        if (isReserving) {
            $scope.firstAvailableTurnForSelectedDoctor = null;
            //$scope.SetReservationTypeForSelectedDoctor();
            $scope.AgreeToFinalBook = false;
            $scope.bookabletimesForSelectedDoctor = null;
            $scope.selectedDoctorDays = null;
            $scope.selectedDoctorDate = null;
            $scope.GetInsurances();

            $scope.refreshMyCaptchaImage('imgcaptchaselecteddoctor');
            $scope.myCaptcha = null;

        } else {

            //if it is for view cv only get doctor's cv
            $scope.getExtraDoctorInfos();
        }
    }
    /// :: ==================================================================





    /// :: ==================================================================
    /// :: Set reservation type for selected doctor
    /// :: ==================================================================
    $scope.SetReservationTypeForSelectedDoctor = function () {

        var _selectedDoctor = $scope.selectedDoctor;

        if (_selectedDoctor && _selectedDoctor != null) {
            switch (_selectedDoctor.reservationType) {
                case "Selective":
                    $scope.InitializeDatePickerForSelectedDoctor();
                    $scope.firstAvailableTurnForSelectedDoctor = null;
                    break;
                case "Sequentially":
                    $scope.GetFirstAvailableTurnForSelectedDoctor(false, false);// False: Not Updating ,  False: Not Updating Force
                    $scope.selectedDoctorDays = null;
                    break;
                default:
                    $scope.GetFirstAvailableTurnForSelectedDoctor(false, false);
                    $scope.selectedDoctorDays = null;
            }
        }

    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Get extra CV data for selected doctor
    /// :: ==================================================================
    $scope.getExtraDoctorInfos = function () {

        $scope.Loading = true;

        var _selectedDoctor = $scope.selectedDoctor;

        if (_selectedDoctor && _selectedDoctor != null) {
            $.blockUI({
                message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw" style="z-index:1051;"></i>'
            });

            $http({
                method: "GET",
                url: "/Public/Appointment/GetExtraDoctorInfos?serviceSupplyId=" + _selectedDoctor.ssId

            }).success(function (data, status, headers, config) {
                $scope.extraDoctorInfos = data;

                $scope.Loading = false;

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");

            });
        }

    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Get Reservable Days For Datepicker
    /// :: ==================================================================
    $scope.InitializeDatePickerForSelectedDoctor = function () {

        var serviceSupplyId = $scope.selectedDoctor.ssId;

        if (serviceSupplyId) {
            $.blockUI({
                message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
            });

            $http({
                method: 'POST',
                url: "/Public/Appointment/getDatePickerDays",
                data: JSON.stringify({
                    serviceSupplyId: serviceSupplyId
                })

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    showMessageBox("هەڵە", data.ErrorMessage, "error");
                    $scope.selectedDoctorDays = null;
                } else {
                    $scope.selectedDoctorDays = data;

                    $("#datepicker1").datepicker("destroy");

                    $("#datepicker1").val("");

                    //Initialize DatePicker Control
                    $("#datepicker1").datepicker({
                        minDate: $scope.selectedDoctorDays.MinDate,
                        maxDate: "+" + $scope.selectedDoctorDays.MaxDate + "D",
                        showButtonPanel: true,
                        showOtherMonths: true,
                        selectOtherMonths: true,
                        isRTL: true,
                        dateFormat: "yy/m/d"
                    });
                    $("#datepicker1btn").click(function (event) {
                        event.preventDefault();
                        $("#datepicker1").focus();
                    })

                    //-------------------------------------
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });

        } else {
            $scope.selectedDoctorDays = null;
            $.unblockUI();
        }

    }
    /// :: ==================================================================



    /// :: ==================================================================
    /// :: Get First Available Turn
    /// :: ==================================================================
    $scope.GetFirstAvailableTurnForSelectedDoctor = function (IsUpdating, IsForce) {

        var oldFirstavailableTurn = null;
        if (IsUpdating && !IsForce) {
            oldFirstavailableTurn = $scope.selectedDoctorSelectedTurn;
        }

        var serviceSupplyId = $scope.selectedDoctor.ssId;

        if (serviceSupplyId) {
            if (!IsUpdating) {
                $.blockUI({
                    message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
                });
            }

            $http({
                method: 'POST',
                url: "/Public/Appointment/getFirstAvailableTurn",
                data: JSON.stringify({
                    serviceSupplyId: serviceSupplyId
                })

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    if (!IsUpdating) {
                        showMessageBox("هەڵە", data.ErrorMessage, "error");
                    }

                    $scope.firstAvailableTurnForSelectedDoctor = null;

                } else {

                    $scope.firstAvailableTurnForSelectedDoctor = data;

                    if (IsUpdating) {
                        if (oldFirstavailableTurn != null) {
                            if (angular.equals(oldFirstavailableTurn, $scope.firstAvailableTurnForSelectedDoctor)) {
                                $scope.selectedDoctorSelectedTurn = null;
                                if (!IsForce) {
                                    showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                                    //$.gotoWizardLevel(1);
                                    localStorage.removeItem('RAFSD');
                                }
                            } else {

                                // می خواهیم بدانیم نوبت قفل شده هنوز هم قفل است یا بعد از مدت زمان معین توسط سرور از حالت قفل خارج شده است
                                $http({
                                    method: 'POST',
                                    url: "/Public/Appointment/isInProgressNow",
                                    data: JSON.stringify({
                                        serviceSupplyId: oldFirstavailableTurn.ServiceSupplyId, date: oldFirstavailableTurn.Date, startTime: oldFirstavailableTurn.StartTime
                                    })

                                }).success(function (data, status, headers, config) {
                                    if (data.Result == "Success" && data.Message == "NO") {
                                        $scope.selectedDoctorSelectedTurn = null;
                                        if (!IsForce) {
                                            showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                                            //$.gotoWizardLevel(1);
                                            localStorage.removeItem('RAFSD');
                                        }
                                    } else {

                                    }

                                }).error(function (data, status, headers, config) {
                                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                                });
                            }
                        }
                    }
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });

        } else {
            $scope.firstAvailableTurnForSelectedDoctor = null;
            $.unblockUI();
        }
    }
    /// :: ==================================================================





    /// :: ==================================================================
    /// :: Get Bookable Times List
    /// :: ==================================================================
    /// :: IsUpdating
    /// این پارامتر نشان می دهد که آیا لیست نوبت ها برای اولین بار ایجاد می شود و یا اینکه با دستور سرور تازه سازی می شود
    /// هنگامی که تازه سازی صورت می گیرد بهتر است بصورت نا محسوس باشد تا کاربر متوجه این کار نشود
    $scope.GetBookableTimesForSelectedDoctor = function (IsUpdating) {

        // برای اینکه بررسی کنیم که آیا نوبتی بعد از بازه زمانی خودکار باز میگردد نوبت انتخاب شده این کلاینت است یا کلاینتهای دیگر
        var tmpOldBookableTimes = null;

        if (IsUpdating) {
            tmpOldBookableTimes = $scope.bookabletimesForSelectedDoctor;
        }

        var date = $scope.selectedDoctorDate;
        if (date == null || date == "") {

            if (!IsUpdating) {
                showMessageBox("هەڵە", 'تکایە بەروارێک هەڵبژێرە', "error");
            }

        } else {
            var serviceSupplyId = $scope.selectedDoctor.ssId;
            if (serviceSupplyId) {
                if (!IsUpdating) { //اگر برای اولین بار لیست نوبت ها ایجاد شود بهتر است سطح پیشرفت کار به کاربر نشان داده شود
                    $.blockUI({
                        message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
                    });
                }

                $http({
                    method: 'POST',
                    url: "/Public/Appointment/getBookableTimes",
                    data: JSON.stringify({
                        serviceSupplyId: serviceSupplyId, date: date
                    })

                }).success(function (data, status, headers, config) {
                    if (data.ErrorMessage != null) {
                        if (!IsUpdating) {
                            showMessageBox("هەڵە", data.ErrorMessage, "error");
                        }
                        $scope.bookabletimesForSelectedDoctor = null;
                    } else {
                        $scope.bookabletimesForSelectedDoctor = data;

                        if (IsUpdating) {
                            // if SelectedTurn not exists in the oldBookableTimes before update
                            // and now exist in the newly updated bookable times
                            // then SelectedTurn = null
                            var existInOldBookableTimes = false;
                            var existInUpdatedBookableTimes = false

                            if ($scope.selectedDoctorSelectedTurn != null) {

                                if (tmpOldBookableTimes != null) {

                                    angular.forEach(tmpOldBookableTimes, function (value, key) {
                                        if (value.DayOfWeek == $scope.selectedDoctorSelectedTurn.DayOfWeek &&
                                            value.Date == $scope.selectedDoctorSelectedTurn.Date &&
                                            value.StartTime == $scope.selectedDoctorSelectedTurn.StartTime &&
                                            value.EndTime == $scope.selectedDoctorSelectedTurn.EndTime &&
                                            value.ServiceSupplyId == $scope.selectedDoctorSelectedTurn.ServiceSupplyId) {
                                            existInOldBookableTimes = true;
                                            return;
                                        }
                                    });
                                }

                                if ($scope.bookabletimes != null) {
                                    angular.forEach($scope.bookabletimesForSelectedDoctor, function (value, key) {
                                        if (value.DayOfWeek == $scope.selectedDoctorSelectedTurn.DayOfWeek &&
                                            value.Date == $scope.selectedDoctorSelectedTurn.Date &&
                                            value.StartTime == $scope.selectedDoctorSelectedTurn.StartTime &&
                                            value.EndTime == $scope.selectedDoctorSelectedTurn.EndTime &&
                                            value.ServiceSupplyId == $scope.selectedDoctorSelectedTurn.ServiceSupplyId) {
                                            existInUpdatedBookableTimes = true;
                                            return;
                                        }

                                    });
                                }

                            }

                            if (!existInOldBookableTimes && existInUpdatedBookableTimes) {
                                // چون نوبت انتخاب شده بعد از مدت زمان مشخص بصورت اتوماتیک بازگشته است مقدار انتخاب شده را خالی می کنیم
                                $scope.selectedDoctorSelectedTurn = null;
                                showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                                //$.gotoWizardLevel(1);
                                localStorage.removeItem('RAFSD');
                            }
                        }
                    }

                    $.unblockUI();

                }).error(function (data, status, headers, config) {
                    $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                    $.unblockUI();
                    if (!IsUpdating) {
                        showMessageBox("هەڵە", $scope.message, "error");
                    }

                });
            }
            else {
                $scope.bookabletimesForSelectedDoctor = null;
                $.unblockUI();
            }

        }

    }
    /// :: ==================================================================




    /// :: ==================================================================
    /// :: Reserve Appointment Temporary
    /// :: ==================================================================
    $scope.ReserveAppointmentForSelectedDoctor = function (bookabletime) {

        $scope.isReservingForSelectedDoctor = true;

        $.blockUI({
            message: '<i class="fa fa-cog fa-spin fa-3x fa-fw" style="color: orange;z-index:1051;"></i>'
        });

        /*if (!appointmentsService.isConnected()) {
            appointmentsService.connect();
        }*/

        $http({
            method: 'POST',
            url: "/Public/Appointment/reserveAppointment",
            data: JSON.stringify({
                serviceSupplyId: bookabletime.ServiceSupplyId,
                date: bookabletime.Date,
                startTime: bookabletime.StartTime,
                endTime: bookabletime.EndTime,
                isSelectedDoctor: true,
                myCaptcha: $scope.myCaptcha
            }),
            headers: {
                'RequestVerificationToken': $scope.antiForgeryToken
            }

        }).success(function (data, status, headers, config) {
            if (data.Result == "Success") {
                angular.element('#timer').text("");
                clearTimeout(countDownTimer);
                startTimer($scope.ExpiredIpaSeconds, $('#timer'));

                $scope.selectedDoctorSelectedTurn = bookabletime;
                $scope.isReservingForSelectedDoctor = false;
                $scope.ReservationTimeForSelectedDoctor = data.ReturnedData;
                $.unblockUI();

                /*try {
                    //Notify other clients that appointment reserved
                    appointmentsService.reserveAppointmentForSelectedDoctor();
                } catch (e) {

                }*/

                //----------------------------------
                $scope.ReservedAppointmentForSelectedDoctor = {
                    selectedTurn: bookabletime,
                    reservationTime: $scope.ReservationTimeForSelectedDoctor
                };

                localStorage.setItem("RAFSD", angular.toJson($scope.ReservedAppointmentForSelectedDoctor));
                //Timer to retrive ipa localy if signalr don't work                
                $scope.retriveIpaTimerForSelectedDoctor = $timeout(function () {
                    var reservedAlready = localStorage.getItem("RAFSD");
                    if (reservedAlready != null) {
                        //var reservedJson = JSON.parse(reservedAlready);
                        $scope.RetriveInprogressAppointmentForSelectedDoctor();
                        $scope.selectedDoctorSelectedTurn = null;
                        $scope.isReservingForSelectedDoctor = false;
                        showMessageBox("هەڵە - رزرڤی نۆرە", "ماوەی گرتنی نۆرە کۆتایی هات", "warning")
                        //$.gotoWizardLevel(1);
                        localStorage.removeItem('RAFSD');
                        $scope.UpdateAppointmentsListForSelectedDoctor();
                    }
                }, $scope.ExpiredIpaMiliSeconds);
                //----------------------------------

            } else {
                showMessageBox("هەڵە", data.Message, "error");
                showMessageBox("هەڵە", "لە کاتی تۆمار کردنی نۆرە هەڵەییک رووی دا", "error");
                $scope.selectedDoctorSelectedTurn = null;
                $scope.isReservingForSelectedDoctor = false;
                $scope.ReservationTimeForSelectedDoctor = null;
                $.unblockUI();
                $scope.UpdateAppointmentsListForSelectedDoctor();
            }
            $.unblockUI();

        }).error(function (data, status, headers, config) {
            //500 Internal Server Error
            if (status == 500) {
                var err500 = "Security Token Expired";
                showMessageBox("ئاگاداری", err500, "warning");
            } else {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
                showMessageBox("هەڵە", $scope.message, "error");
            }
            $scope.selectedDoctorSelectedTurn = null;
            $scope.isReservingForSelectedDoctor = false;
            $scope.ReservationTimeForSelectedDoctor = null;
            $.unblockUI();
        });

    }
    /// :: ==================================================================




    $scope.RetriveInprogressAppointmentForSelectedDoctor = function () {
        var ipa = $scope.selectedDoctorSelectedTurn;

        if (ipa && ipa != null) {

            $.blockUI({
                message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
            });

            $http({
                method: 'POST',
                url: "/Public/Appointment/retriveInprogressAppointmentForce",
                data: JSON.stringify({
                    serviceSupplyId: ipa.ServiceSupplyId, date: ipa.Date, startTime: ipa.StartTime, isSelectedDoctor: true
                })

            }).success(function (data, status, headers, config) {
                if (data.Result == "Success") {

                    clearTimeout(countDownTimer);

                    $scope.selectedDoctorSelectedTurn = null;
                    $scope.isReservingForSelectedDoctor = false;
                    //showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "info");
                    localStorage.removeItem('RAFSD');
                    $timeout.cancel($scope.retriveIpaTimerForSelectedDoctor);
                    $scope.AgreeToFinalBook = false;
                    //$.gotoWizardLevel(2);
                    $scope.UpdateAppointmentsListForSelectedDoctor();
                } else {
                    //showMessageBox("پاشگەزبونەوە لە نۆرە", data.Message, "error");
                }
                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی لە گەڵ سەرڤەر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
            });
        }
    }




    ///in this method we update list of available appointments in normal mode with showing loader to user.
    $scope.UpdateAppointmentsListForSelectedDoctor = function () {
        var _selectedDoctor = $scope.selectedDoctor;

        if (_selectedDoctor && _selectedDoctor != null) {
            switch (_selectedDoctor.reservationType) {
                case "Selective":
                    $scope.GetBookableTimesForSelectedDoctor(false);
                    break;
                case "Sequentially":
                    $scope.GetFirstAvailableTurnForSelectedDoctor(false, false);
                    break;
                default:
                    $scope.GetBookableTimesForSelectedDoctor(false);
            }
        }
    }




    /// :: ==================================================================
    /// :: Final Booking Appointment For Selected Doctor
    /// :: ==================================================================
    $scope.FinalBookAppointmentForSelectedDoctor = function () {

        $.blockUI({ message: '<i class="fa fa-cog fa-spin fa-3x fa-fw"></i>' });

        $http({
            method: 'POST',
            url: "/Public/Appointment/finalBookAppointment",
            data: JSON.stringify({
                ServiceSupplyId: $scope.selectedDoctorSelectedTurn.ServiceSupplyId,
                Date: $scope.selectedDoctorSelectedTurn.Date,
                StartTime: $scope.selectedDoctorSelectedTurn.StartTime,
                EndTime: $scope.selectedDoctorSelectedTurn.EndTime,
                FirstName: $scope.firstName,
                SecondName: $scope.secondName,
                ThirdName: $scope.thirdName,
                Mobile: $scope.mobile,
                Gender: $scope.gender,
                Email: $scope.email,
                ExistUser: $scope.ExistUser,
                ReservationTime: $scope.ReservationTimeForSelectedDoctor,
                //captcharesponse: $scope.captcharesponse,
                MyCaptcha: $scope.myCaptcha
            }),
            headers: {
                'RequestVerificationToken': $scope.antiForgeryToken
            }

        }).success(function (data, status, headers, config) {
            if (data.Result == "Success") {

                //Make data ready to print factor
                $scope.readyToPrintFactor = true;
                $scope.printselectedDoctorSelectedTurn = $scope.selectedDoctorSelectedTurn;
                $scope.printMobile = $scope.mobile;
                $scope.printFirstName = $scope.firstName;
                $scope.printLastName = $scope.secondName;
                $scope.printGender = $scope.gender;
                $scope.printEmail = $scope.email;

                //:: Empty all variables
                $scope.selectedDoctorSelectedTurn = null;

                showMessageBox('رزرڤی نۆرە', data.Message, "info");

                //Cancel auto retrive timer
                $timeout.cancel($scope.retriveIpaTimerForSelectedDoctor);
                /*try {
                    appointmentsService.reserveAppointmentForSelectedDoctor();
                } catch (e) {

                }*/
                localStorage.removeItem('RAFSD');

                $scope.AgreeToFinalBook = false;

                //Clear User Entered Data
                $scope.wrongMobile = true;
                $scope.ExistUser = false;
                $scope.mobile = null;
                $scope.firstName = null;
                $scope.lastName = null;
                $scope.mobilePhone = null;
                $scope.gender = null;
                $scope.email = null;
                $scope.insurances = null;
                $scope.insuranceNumber = null;
                $scope.Password = null;
                $scope.confirmPassword = null;
            } else {
                showMessageBox("رزرڤی نۆرە", data.Message, "error");
            }
            $.unblockUI();
            //grecaptcha.reset(captchaWidget2);
            //$scope.captcharesponse = null;

            $scope.refreshMyCaptchaImage('imgcaptchaselecteddoctor');
            $scope.myCaptcha = null;

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

            $.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");
            //grecaptcha.reset(captchaWidget2);
            //$scope.captcharesponse = null;

            $scope.refreshMyCaptchaImage('imgcaptchaselecteddoctor');
            $scope.myCaptcha = null;
        });

    }
    /// :: ==================================================================





    ////////////////////////////////////////////////////////////////
    /// :: SignalR Realtiming Methods For Selected Doctor
    ////////////////////////////////////////////////////////////////
    $scope.$on("appointmentReservedForSelectedDoctor", function (event) {

        var _selectedDoctor = $scope.selectedDoctor;

        if (_selectedDoctor && _selectedDoctor != null) {
            switch (_selectedDoctor.reservationType) {
                case "Selective":
                    $scope.GetBookableTimesForSelectedDoctor(true);
                    break;
                case "Sequentially":
                    $scope.GetFirstAvailableTurnForSelectedDoctor(true, false);
                    break;
                default:
                    $scope.GetBookableTimesForSelectedDoctor(true);
            }
        }

        $scope.$apply();
    })


    $scope.$on("appointmentRecoveredForSelectedDoctor", function (event) {

        var _selectedDoctor = $scope.selectedDoctor;

        if (_selectedDoctor && _selectedDoctor != null) {
            switch (_selectedDoctor.reservationType) {
                case "Selective":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimesForSelectedDoctor(true);
                    break;
                case "Sequentially":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetFirstAvailableTurnForSelectedDoctor(true, false);
                    break;
                default:
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimesForSelectedDoctor(true);
            }
        }

        $scope.$apply();
    })


    $scope.$on("appointmentRecoveredForceForSelectedDoctor", function (event) {

        var _selectedDoctor = $scope.selectedDoctor;

        if (_selectedDoctor && _selectedDoctor != null) {
            switch (_selectedDoctor.reservationType) {
                case "Selective":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimesForSelectedDoctor(true);
                    break;
                case "Sequentially":
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetFirstAvailableTurnForSelectedDoctor(true, true);
                    break;
                default:
                    // True means that the bookable times list are updating and not load for first time...
                    $scope.GetBookableTimesForSelectedDoctor(true);
            }
        }

        $scope.$apply();
    })
    /////////////////////////////////////////////////////////////////


    //****************************** Patient Section to tracking appointments ****************************
    //Scope Declaration
    $scope.responseData = "";

    $scope.userName = "";

    $scope.userLoginName = "";
    $scope.userLoginPassword = "";

    $scope.accessToken = sessionStorage.getItem('accessToken');
    $scope.refreshToken = "";

    $scope.logedInFirstName = sessionStorage.getItem('firstName');
    $scope.logedInLastName = sessionStorage.getItem('lastName');
    $scope.logedInAvatar = sessionStorage.getItem('avatar');

    $scope.appointmentsStatuses = [
        { id: 'P', name: "Pending" },
        {
            id: 'D', name: "Done"
        },
        {
            id: 'C', name: "Canceled"
        }
    ];
    //Ends Here

    //Function to Login. This will generate Token 
    $scope.login = function () {
        $.blockUI({
            message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>'
        });
        //This is the information to pass for token based authentication
        var userLogin = {
            grant_type: 'password',
            username: $scope.userLoginName,
            password: $scope.userLoginPassword
        };

        var promiselogin = loginService.login(userLogin);

        promiselogin.then(function (resp) {
            //Check if user have Patient role or not?
            var patientRole = "5";
            var isPatient = resp.data.r.indexOf(patientRole) != -1;
            //if (isPatient) {
            $scope.userName = resp.data.userName;
            //Store the token information in the SessionStorage
            //So that it can be accessed for other views
            sessionStorage.setItem('userName', resp.data.userName);
            sessionStorage.setItem('accessToken', resp.data.access_token);
            sessionStorage.setItem('refreshToken', resp.data.refresh_token);
            $scope.accessToken = resp.data.access_token;
            $.unblockUI();
            var getUserInfo = patientService.get();
            getUserInfo.then(function (response) {
                $.unblockUI();
                sessionStorage.setItem('firstName', response.data.Name);
                sessionStorage.setItem('lastName', response.data.Family);
                sessionStorage.setItem('avatar', response.data.Avatar);

                $scope.logedInFirstName = response.data.Name;
                $scope.logedInLastName = response.data.Family;
                $scope.logedInAvatar = response.data.Avatar;
            }, function (error) {
                $.unblockUI();

            });
            //} else {
            //    $.unblockUI();
            //    showMessageBox("هەڵە", "ئێوە نەخۆش نین", "error")
            //    logout();
            //}

        }, function (err) {
            $.unblockUI();
            var message = "";
            switch (err.status) {
                case 400:
                    message = "ناوی بەکارهێنەر یان ووشەی نهێنی درووست نیە";
                    showMessageBox("هەڵە", message, "error");
                    break;
            }
        });

    };



    $scope.getAppointments = function () {
        $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });
        var getPatientAppointments = patientService.appointments($scope.patientId, $scope.patientDateFrom, $scope.patientDateTo, $scope.patientAppointmentStatus, $scope.patientDoctorName);
        getPatientAppointments.then(function (response) {
            $.unblockUI();

            $scope.patientAppointments = response.data;

        }, function (error) {
            $.unblockUI();
        });
    }
    $scope.AppointmentId;
    $scope.askCancel = function (aid) {
        $('#confirmModal').modal('toggle');
        $scope.AppointmentId = aid;
        console.log($scope.AppointmentId)
    };

    $scope.realityDelete = function () {
        $http({
            method: 'POST',
            url: "/api/public/turns/setstatus",
            data: JSON.stringify({
                AppointmentId: $scope.AppointmentId,
                Status: 2
            }),
            headers: {
                'Authorization': "Bearer " + sessionStorage.getItem('accessToken')
            }

        }).success(function (data, status, headers, config) {
            $scope.getAppointments()
            $('#confirmModal').modal('toggle');
        }).error(function (data, status, headers, config) {
            $('#confirmModal').modal('toggle');
            $scope.message = 'Please try again';
            //$.unblockUI();
            showMessageBox("هەڵە", $scope.message, "error");
        });
    };


    $scope.logout = function () {
        sessionStorage.removeItem('accessToken');
        $scope.accessToken = "";

        sessionStorage.removeItem('firstName');
        sessionStorage.removeItem('lastName');
        sessionStorage.removeItem('avatar');

        $scope.logedInFirstName = "";
        $scope.logedInLastName = "";
        $scope.logedInAvatar = "";
        showMessageBox("سەرکەوتن", "بە سەرکەووتویی دەرچوون", "info");
    };

    //********************** End Patient Section *********************************


}]);