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
            var a = userService.user;
            userService.getUserId.then(
                function (result) {

                },
                function (error) {

                }
            );

            console.log(a);
        }

        function activate() {
            getAllPets();
        }
    }
})();