
mainApp.controller("registerController", ["$scope", "$http", function ($scope, $http) {    
         
    GetProvincesForRegisterForm();

    /// :: ==================================================================
    /// :: Get Provinces List
    /// :: ==================================================================
    function GetProvincesForRegisterForm() {

        $http({
            method: "GET",
            url: "/Public/Home/GetProvinces"

        }).success(function (data, status, headers, config) {
            if (data.ErrorMessage != null) {
                // خطای سمت سرور
                showMessageBox("هەلە", data.ErrorMessage, "error");
                $scope.provinces = null;
            } else {
                $scope.provinces = data;
            }

        }).error(function (data, status, headers, config) {
            $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';
            showMessageBox("هەلە", $scope.message, "error");

            $scope.cities = null;

        });
    }
    /// :: ==================================================================


    /// :: ==================================================================
    /// :: Get Cities List
    /// :: ==================================================================
    $scope.GetCitiesFormRegisterForm = function () {

        var _provinceId = $scope.province;
        if (_provinceId) {
            $.blockUI({ message: '<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>' });

            $http({
                method: 'POST',
                url: "/Public/Home/GetCities",
                data: JSON.stringify({
                    provinceId: _provinceId
                })

            }).success(function (data, status, headers, config) {
                if (data.ErrorMessage != null) {
                    showMessageBox("هەلە", data.ErrorMessage, "error");
                    $scope.cities = null;
                } else {
                    $scope.cities = data;                   
                }

                $.unblockUI();

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەلە", $scope.message, "error");
            });
        }
        else {
            $scope.cities = null;
            $.unblockUI();
        }
    }
    /// :: ==================================================================


    /// :: ==================================================================
    /// :: Register PoliClinic Request
    /// :: ==================================================================
    $scope.SubmitPoliClinicRequest = function () {
      
            $.blockUI({ message: '<i class="fa fa-cog fa-spin fa-3x fa-fw" style="color:blue;"></i>' });

            $http({
                method: 'POST',
                url: "/Public/Register/RegisterPoliClinic",
                data: JSON.stringify({
                    Name: $scope.firstName,
                    Family: $scope.lastName,
                    Mobile: $scope.mobilePhone,
                    Email: $scope.email,
                    PoliClinicName: $scope.policlinicName,
                    ProvinceId: $scope.province,
                    CityId: $scope.city,
                    PoliClinicAddress: $scope.policlinicAddress,
                    PoliClinicPhones: $scope.policlinicPhone,
                    PoliClinicDescription: $scope.policlinicDesc,
                    ExistUser: $scope.ExistUser,
                    CaptchaResponse: $scope.captcharesponse
                }),
                headers: {
                    'RequestVerificationToken': $scope.antiForgeryToken
                }

            }).success(function (data, status, headers, config) {
                if (data.Result == "Success") {
                    //Clear User Entered Data                
                    $scope.firstName = null;
                    $scope.lastName = null;
                    $scope.mobilePhone = null;
                    $scope.email = null;
                    $scope.policlinicName = null;
                    $scope.province = null;
                    $scope.city = null;
                    $scope.policlinicAddress = null;
                    $scope.policlinicPhone = null;
                    $scope.policlinicDesc = null;

                    //window.location.href = "/Public/Register/RegisterSuccess"
                    $scope.RegisterSuccessful = true;
                } else {
                    $scope.message = 'داواکاریەکەت بە سەرکەووتویی تۆمار کرا';
                    showMessageBox("هەڵە", $scope.message, "error");

                    $scope.RegisterSuccessful = false;
                }
                $.unblockUI();
                //grecaptcha.reset(captchaWidget1);
                $scope.captcharesponse = null;

            }).error(function (data, status, headers, config) {
                $scope.message = 'هەڵە لە پەیوەندی بە سیرڤر';

                $.unblockUI();
                showMessageBox("هەڵە", $scope.message, "error");
                //.reset(captchaWidget1);
                $scope.captcharesponse = null;
                $scope.RegisterSuccessful = false;
            });
    }
    /// :: ==================================================================


    function showMessageBox(_title, _message, _type) {
        $.msgBox({
            title: _title,
            content: _message,
            type: _type,
            modal: true
        });
    }


}]);