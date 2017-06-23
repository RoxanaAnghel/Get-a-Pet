(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('homeService', homeService);

    homeService.$inject = ['$http'];

    function homeService($http) {

        this.getAllPets = getAllPets;

        function getAllPets() {
            return $http({
                method: 'GET',
                url: window.location.origin + '/api/pets'
            });
        }
    }
})();