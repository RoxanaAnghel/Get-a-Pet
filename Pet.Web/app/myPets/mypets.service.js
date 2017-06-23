(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('myPetsService', myPetsService);

    myPetsService.$inject = ['$http'];

    function myPetsService($http) {

        this.getAllPets = getAllPets;

        function getAllPets(userId) {
            return $http({
                method: 'GET',
                url: window.location.origin + '/api/pets/' + userId
            });
        }
    }
})();