(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['homeService', '$scope'];

    function HomeController(homeService, scope) {

        var vm = this;
        vm.pets = [];

        activate();

        function getAllPets() {
            homeService.getAllPets()
                .then(function (result) {
                    vm.pets = result.data;
                });
        }

        function activate() {
            getAllPets();
        }
    }
})();