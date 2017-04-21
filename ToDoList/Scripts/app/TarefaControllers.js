var modules = modules || [];
(function () {
    'use strict';
    modules.push('Tarefa');

    angular.module('Tarefa', ['ngRoute'])
        .controller('TarefaController', [
            '$scope', '$http', function($scope, $http) {
                $scope.task = {};

                $scope.get = function() {
                    $http.get('/Api/Tarefa/')
                        .then(function(response) { $scope.data = response.data; });
                }

                $scope.toggle = function(item) {
                    item.Status = !item.Status;
                    $http.put('/Api/Tarefa/' + item.Id, item)
                        .then(function(response) {
                            $scope.get();
                        });
                }

                $scope.edit = function(item) {
                    $scope.task = item;
                }

                $scope.delete = function(item) {
                    $http.delete('/Api/Tarefa/' + item.Id, item)
                        .then(function(response) {
                            $scope.get();
                        });
                }

                $scope.save = function() {
                    if ($scope.task.Id == undefined || $scope.task.Id == null) {
                        $http.post('/Api/Tarefa/', $scope.task)
                            .then(function(response) {
                                $scope.task = {};
                                $scope.get();
                            });
                    } else {
                        $http.put('/Api/Tarefa/' + $scope.task.Id, $scope.task)
                            .then(function(response) {
                                $scope.task = {};
                                $scope.get();
                            });
                    }
                }

                $scope.get();
            }
        ]);
})();
