(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['myPetsService', '$scope', '$mdDialog'];

    function HomeController(myPetsService, scope, $mdDialog) {

        var vm = this;
        vm.pets = [];
        vm.getPetProfile = getPetProfile;
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

        function getPetProfile(ev,petId) {
            console.log("in pet profile get");
            $mdDialog.show({
                controller: PetProfileViewController,
                controllerAs: PetProfileViewController,
                templateUrl: window.location.origin + "/Templates/PetViewProfile.cshtml",
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true
            })
                .then(function (answer) {
                    $scope.status = 'You said the information was "' + answer + '".';
                }, function () {
                    $scope.status = 'You cancelled the dialog.';
                });

        }
    }
})();