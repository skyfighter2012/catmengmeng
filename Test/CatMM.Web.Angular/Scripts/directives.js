'use strict';

angular.module('app.directives', [])
.directive('appVersion', ['version', function (version) {
    return function (scope, elm, attrs) {
        elm.text(version);
    };
}])
.directive('integer', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            var INTEGER_REGEXP = /^(\+|-)?([1-9]\d*|0)$/;
            ctrl.$validators.integer = function (modelValue, viewValue) {
                console.log("modelValue:" + modelValue + "  viewValue:" + viewValue);
                if (ctrl.$isEmpty(modelValue)) {
                    // consider empty models to be valid
                    return true;
                }

                if (INTEGER_REGEXP.test(viewValue)) {
                    // it is valid
                    return true;
                }

                // it is invalid
                return false;
            }
        }
    }
})
.directive('contenteditable', function () {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            // view -> model
            elm.on('blur', function () {
                ctrl.$setViewValue(elm.html());
            });

            // model -> view
            ctrl.$render = function () {
                elm.html(ctrl.$viewValue);
            };

            // load init value from DOM
            ctrl.$setViewValue(elm.html());
        }
    }
})