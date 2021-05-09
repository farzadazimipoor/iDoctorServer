mainApp.service('turnsService', ["$http", function ($http) {
    this.bookableTurns = function (doctorId, healthServiceId, date, locale) {
        var request = $http({
            method: 'GET',
            url: "/api/awronore/turns/bookables/" + doctorId + "/" + healthServiceId + "/" + date,
            headers: { 'Accept-Language': locale },
        });
        return request;
    };   

    this.finalBookAppointment = function (model, locale) {
        var request = $http({
            method: 'POST',
            url: "/api/awronore/turns/finalbook",
            headers: { 'Accept-Language': locale },
            data: model
        });
        return request;
    };   
}]);