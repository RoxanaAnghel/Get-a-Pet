(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('userService', userService);

    userService.$inject = ['$http'];

    function userService($http) {

        this.getUserId = getUserId;

        function getUserId() {
            return $http({
                method: 'GET',
                url: '/api/userdetails'
            });
        }
    }
})();