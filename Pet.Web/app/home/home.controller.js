(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['myPetsService', '$scope'];

    function HomeController(myPetsService, scope) {

        var vm = this;
        vm.pets = [];

        activate();

        function getAllPets() {
            myPetsService.getAllPets()
                .then(function (result) {
                    vm.pets = result.data;
                });
        }

        function activate() {
            getAllPets();
        }
    }
})();