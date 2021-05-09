mainApp.service('patientService', ["$http", function ($http) {

    this.get = function () {
        var accessToken = sessionStorage.getItem('accessToken');

        var authHeaders = {};
        if (accessToken) {
            authHeaders.Authorization = 'Bearer ' + accessToken;
        }

        var response = $http({
            url: "/api/patient",
            method: "GET",
            headers: authHeaders
        });
        return response;
    }


    this.appointments = function (from, to, status, doctorName) {
        var accessToken = sessionStorage.getItem('accessToken');

        var authHeaders = {};
        if (accessToken) {
            authHeaders.Authorization = 'Bearer ' + accessToken;
        }

        var response = $http({
            url: "/api/patient/100/0/appointments",
            method: "POST",
            data: {
                DateFrom: from,
                DateTo: to,
                Status: status,
                DoctorName: doctorName
            },
            headers: authHeaders
        });
        return response;
    }

    this.cancel = function (ServiceSupplyId, Date, StartTime, ReservationTime, IsForIndependentDoctor) {
        var accessToken = sessionStorage.getItem('accessToken');

        var authHeaders = {};
        if (accessToken) {
            authHeaders.Authorization = 'Bearer ' + accessToken;
        }

        var response = $http({
            url: "/api/patient/100/0/appointments",
            method: "POST",
            data: {
                DateFrom: from,
                DateTo: to,
                Status: status,
                DoctorName: doctorName
            },
            headers: authHeaders
        });
        return response;
    }

}]);