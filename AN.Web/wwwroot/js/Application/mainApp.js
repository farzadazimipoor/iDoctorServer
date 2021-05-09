var mainApp = angular.module("mainApp", ['ngResource']);


angular.module('myModule', ['cp.ngConfirm'])


mainApp.value("$", $);


//Check two passwords to be same
mainApp.directive('pwCheck', [function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            var firstPassword = '#' + attrs.pwCheck;
            elem.add(firstPassword).on('keyup', function () {
                scope.$apply(function () {
                    var v = elem.val() === $(firstPassword).val();
                    ctrl.$setValidity('pwmatch', v);
                });
            });
        }
    }
}]);

mainApp.service('loginService', ["$http", function ($http) {

    this.login = function (userlogin) {

        var resp = $http({
            url: "/token",
            method: "POST",
            data: $.param({ grant_type: 'password', username: userlogin.username, password: userlogin.password }),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        });
        return resp;
    };

}]);


//valid-number directive to enter only digits in textbox
mainApp.directive('validNumber', function () {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            // make sure we're connected to a model
            if (!ngModelCtrl) {
                return;
            }

            ngModelCtrl.$parsers.push(function (val) {
                // this is a test for whether it's undefined (from textbox)
                // or null when using type="number"
                if (val === undefined || val === null) {
                    val = '';
                }

                // here we try and clean it to make sure it's only numbers
                var clean = val.toString().replace(/[^0-9]+/g, '');

                // if a letter/etc got in there, set the model to the "cleaned" number value
                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });

            // this is to test for "32" = SPACEBAR
            // and "101" = e (Chrome for some reason let's E go through in type="number"
            element.bind('keypress', function (e) {
                var code = e.keyCode || e.which;

                // Remove code === 101 part if you want 'e' to go through
                if (code === 101 || code === 32) {
                    e.preventDefault();
                }
            });
        }
    };
});

//replace and with directives to enter only alphabet in input text
mainApp.directive('replace', function () {
    return {
        require: 'ngModel',
        scope: {
            regex: '@replace',
            with: '@with'
        },
        link: function (scope, element, attrs, model) {
            model.$parsers.push(function (val) {
                if (!val) { return; }
                var regex = new RegExp(scope.regex);
                var replaced = val.replace(regex, scope.with);
                if (replaced !== val) {
                    model.$setViewValue(replaced);
                    model.$render();
                }
                return replaced;
            });
        }
    };
});
//letters-only directive used with replace directive
//this directive replace all numbers with ""
mainApp.directive('lettersOnly', function () {
    return {
        replace: true,
        template: '<input replace="[0-9]" with="">'
    };
})

mainApp.filter('iif', function () {
    return function (input, trueValue, falseValue) {
        return input ? trueValue : falseValue;
    };
});