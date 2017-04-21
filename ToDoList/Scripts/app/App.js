var modules = modules || [];
angular.module('app', modules);
angular.module('app').controller('MainMenu', ['$scope', function ($scope) {
    $scope.modules = modules;
}])
.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/Tarefa', {
            title: 'Tarefas',
            templateUrl: '/home/Index',
            controller: 'Tarefa_list'
        });
}])
    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.hashPrefix('');
    }]);
