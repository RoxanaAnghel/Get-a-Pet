(function () {
    'use strict'

    angular
        .module('getAPet', ['ngRoute', 'ngMaterial'])
        .factory('httpRequestInterceptor', function () {
            return {
                request: function (config) {
                    return config;
                }
            };
        })
        .config(function ($routeProvider, $httpProvider) {
            $httpProvider.interceptors.push('httpRequestInterceptor');
            $routeProvider
                .when("/home", {
                    templateUrl: window.location.origin + "/Templates/Home",
                    controller: "HomeController",
                    controllerAs: "homeController"
                })
                .when("/mypets", {
                    templateUrl: window.location.origin + "/Templates/MyPets",
                    controller: "MyPetsController",
                    controllerAs: "myPetsController"
                })
                .when("/pet-save", {
                    templateUrl: window.location.origin + "/Templates/PetSave",
                    controller: "PetSaveController",
                    controllerAs: "petSaveController"
                })
                .otherwise({ redirectTo: "/home" });
        });
})();