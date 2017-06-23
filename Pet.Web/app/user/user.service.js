(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('userService', userService);

    userService.$inject = ['$http'];

    function userService($http) {

        this.userId = getUserId;
        this.user = 11;
        //console.log(userId);

        function getUserId() {
            return $http({
                method: 'GET',
                url: 'api/userdetails'
            });
        }
    }
})();