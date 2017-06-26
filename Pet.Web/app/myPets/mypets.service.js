(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('myPetsService', myPetsService);

    myPetsService.$inject = ['$http'];

    function myPetsService($http) {

        this.getAllPets = getAllPets;
        var query=""
        function getAllPets(userId) {
            var params = { ownerId: userId }
            if (userId) {
                query = "?ownerId=" + userId
            }
            return $http({
                method: 'GET',
                url: '/api/pets' + query
            });
        }
    }
})();