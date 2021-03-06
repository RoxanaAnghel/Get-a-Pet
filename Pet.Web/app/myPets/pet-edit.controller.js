﻿(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('PetEditController', PetEditController);

    PetEditController.$inject = ['myPetsService', '$scope', '$routeParams','$location'];

    function PetEditController(myPetsService, scope, $routeParams, location) {

        var vm = this;
        vm.save = save;
        vm.pet = vm.pet = {

            Name: "",
            Location: "",
            ImageUrl: "",
            Description: "",
            Species: 0,
            Breed: "",
            PureBreed: false,
            MainColour: 0,
            FurType: 0,
            Size: 0,
            Adopted: false,
            BirthDate: false
        };
        vm.save = save;
        vm.cancel = cancel;
        load();


        function load() {
            myPetsService.getPet($routeParams.petId).
                then(function (result) {
                    vm.pet = result.data;
                });
        }

        function save() {
            myPetsService.updatePet(vm.pet).
                then(function () {
                    location.path("/mypets");
                });
        }

        function cancel() {
            location.path("/mypets");
        }

        
    }
})();