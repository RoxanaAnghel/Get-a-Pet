(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('PetEditController', PetEditController);

    PetEditController.$inject = ['myPetsService', '$scope', '$routeParams','$location'];

    function PetEditController(myPetsService, scope, $routeParams, location) {

        var vm = this;
        vm.save = save;
        vm.pet = {};
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