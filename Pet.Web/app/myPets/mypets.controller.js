(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('MyPetsController', MyPetsController);

    MyPetsController.$inject = ['myPetsService', '$scope','userService'];

    function MyPetsController(myPetsService, scope,userService) {

        var vm = this;
        vm.pets = [];
        vm.current = '';

        activate();

        function getAllPets() {
            userService.getUserId().then(
                function (result) {
                     myPetsService.getAllPets(result.data)
                         .then(function (result) {
                             vm.pets = result.data;
                        });
                },
                function (error) {

                });
        }

        function activate() {
            getAllPets();
        }
    }
})();