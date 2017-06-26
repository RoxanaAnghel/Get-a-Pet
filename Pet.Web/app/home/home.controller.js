(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['myPetService', '$scope'];

    function HomeController(myPetService, scope) {

        var vm = this;
        vm.pets = [];

        activate();

        function getAllPets() {
            myPetService.getAllPets()
                .then(function (result) {
                    vm.pets = result.data;
                });
        }

        function activate() {
            getAllPets();
        }
    }
})();