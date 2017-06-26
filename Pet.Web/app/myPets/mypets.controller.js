(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('MyPetsController', MyPetsController);

    MyPetsController.$inject = ['myPetsService', '$scope','userService','$location'];

    function MyPetsController(myPetsService, scope,userService,location) {

        var vm = this;
        vm.pets = [];
        vm.current = '';
        vm.deletePet = deletePet;
        vm.goToSave = goToSave;
        vm.goToEdit = goToEdit;
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

        function deletePet(petId) {
            myPetsService.deletePet(petId)
                .then(function () {
                    getAllPets();
                });
        }

        function goToSave(pet) {
            console.log("in create new");
            location.path("/pet-save");
        }

        function goToEdit(petId) {
            console.log("in create new");
            location.path("/pet-edit/"+petId);
        }

        function activate() {
            getAllPets();
        }
    }
})();