mainApp.service('doctorsService', ["$http", function ($http) {

    this.search = function (filterModel, pageIndex, limit) {
        var request = $http({
            method: 'POST',
            url: "/api/awronore/doctors/" + pageIndex + "/" + limit,           
            data: filterModel
        });
        return request;
    };

    this.reserve = function (id, locale) {
        var request = $http({
            method: 'GET',
            url: "/api/awronore/turns/reserve/" + id,   
            headers: { 'Accept-Language': locale },
        });
        return request;
    }    
}]);