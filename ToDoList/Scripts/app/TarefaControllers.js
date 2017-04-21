var modules = modules || [];
(function () {
    'use strict';
    modules.push('Tarefa');

    angular.module('Tarefa', ['ngRoute'])
    .controller('Tarefa_list', ['$scope', '$http', '$location', function ($scope, $http, $location) {
        $scope.task = {};

        $scope.get = function () {
            $http.get('/Api/Tarefa/')
            .then(function (response) { $scope.data = response.data; });
        }

        $scope.toggle = function (item) {
            item.Status = !item.Status;
            $http.put('/Api/Tarefa/' + item.Id, item)
            .then(function (response) {
                $scope.get();
            });
        }

        $scope.edit = function (item) {
            $scope.task = item;
        }

        $scope.delete = function (item) {
            $http.delete('/Api/Tarefa/' + item.Id, item)
            .then(function (response) {
                $scope.get();
            });
        }

        $scope.save = function () {
            if ($scope.task.Id == undefined || $scope.task.Id == null) {
                $http.post('/Api/Tarefa/', $scope.task)
                .then(function (response) {
                    $scope.task = {};
                    $scope.get();
                });
            } else {
                $http.put('/Api/Tarefa/' + $scope.task.Id, $scope.task)
            .then(function (response) {
                $scope.task = {};
                $scope.get();
            });
            }
        }

        $scope.get();
    }])
    .controller('Tarefa_details', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {

        $http.get('/Api/Tarefa/' + $routeParams.id)
        .then(function (response) { $scope.data = response.data; });

    }])
    .controller('Tarefa_create', ['$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {

        $scope.data = {};
        //$scope.data.DataCriacao = new Date();
        //$scope.data.DataConclusao = new Date();
        //$scope.data.DataExclusao = new Date();
        //$scope.data.DataEdicao = new Date();

        $scope.save = function () {
            //$scope.data.DataCriacao = new Date($scope.data.DataCriacao);
            $http.post('/Api/Tarefa/', $scope.data)
            .then(function (response) { $location.path("Tarefa"); });
        }

    }])
    .controller('Tarefa_edit', ['$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {

        $http.get('/Api/Tarefa/' + $routeParams.id)
        .then(function (response) { $scope.data = response.data; });


        $scope.save = function () {
            $http.put('/Api/Tarefa/' + $routeParams.id, $scope.data)
            .then(function (response) { $location.path("Tarefa"); });
        }

    }])
    .controller('Tarefa_delete', ['$scope', '$http', '$routeParams', '$location', function ($scope, $http, $routeParams, $location) {

        $http.get('/Api/Tarefa/' + $routeParams.id)
        .then(function (response) { $scope.data = response.data; });
        $scope.save = function () {
            $http.delete('/Api/Tarefa/' + $routeParams.id, $scope.data)
            .then(function (response) { $location.path("Tarefa"); });
        }

    }])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/Tarefa', {
                title: 'Tarefa - List',
                templateUrl: '/Static/Tarefa_List',
                controller: 'Tarefa_list'
            })
            .when('/Tarefa/Create', {
                title: 'Tarefa - Create',
                templateUrl: '/Static/Tarefa_Edit',
                controller: 'Tarefa_create'
            })
            .when('/Tarefa/Edit/:id', {
                title: 'Tarefa - Edit',
                templateUrl: '/Static/Tarefa_Edit',
                controller: 'Tarefa_edit'
            })
            .when('/Tarefa/Delete/:id', {
                title: 'Tarefa - Delete',
                templateUrl: '/Static/Tarefa_Delete',
                controller: 'Tarefa_delete'
            })
            .when('/Tarefa/:id', {
                title: 'Tarefa - Details',
                templateUrl: '/Static/Tarefa_Details',
                controller: 'Tarefa_details'
            });
    }])
    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.hashPrefix('');
    }]);


})();
