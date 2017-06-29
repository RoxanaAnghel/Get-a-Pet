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
        vm.search = false;
        vm.showInput = false;
        vm.showSearch = showSearch;
        vm.clearSearch = clearSearch;
        vm.hideSearch = hideSearch;

        vm.searchOptions = {
            Species: 0,
            Color: 0,
            PureBreed: false,
            Breed: '',
            Size: 0,
            Fur: 0
        };

        activate();

        function hideSearch() {
            vm.showInput = false;
        }

        function showSearch() {
            vm.search = true;
            vm.showInput = true;
        }

        function clearSearch() {
            vm.search = false;
            vm.showInput = false;
        }

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