mainApp.service('loginService', ["$http", function ($http) {
    this.showLoginModal = function (locale) {
        var request = $http({
            method: 'GET',
            url: "/Login",
            headers: { 'Accept-Language': locale },
        });
        return request;
    };    

    this.checkMobileAndGetOTP = function (locale, mobile) {
        var request = $http({
            method: 'GET',
            url: "/api/awronore/login/mobile/" + mobile,
            headers: { 'Accept-Language': locale },
        });
        return request;
    };   
}]);