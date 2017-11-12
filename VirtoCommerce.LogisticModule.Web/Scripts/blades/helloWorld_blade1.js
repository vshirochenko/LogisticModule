angular.module('LogisticModule')
.controller('LogisticModule.blade1Controller', ['$scope', 'LogisticModuleApi', function ($scope, api) {
    var blade = $scope.blade;
    blade.title = 'LogisticModule';

    blade.refresh = function () {
        api.get(function (data) {
            blade.data = data.result;
            blade.isLoading = false;
        });
    }

    blade.refresh();
}]);
