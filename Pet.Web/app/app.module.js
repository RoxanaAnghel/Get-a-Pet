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
                .otherwise({ redirectTo: "/home" });
        });
})();