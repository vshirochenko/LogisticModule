angular.module('LogisticModule')
.controller('LogisticModule.blade1Controller', ['$scope', 'LogisticModuleApi', function ($scope, api) {
    var blade = $scope.blade;
    blade.title = 'LogisticModule';

    blade.refresh = function () {
        blade.data = 'ui not implemented';
    }

    blade.refresh();
}]);
