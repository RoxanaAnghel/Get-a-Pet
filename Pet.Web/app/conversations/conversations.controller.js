(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('conversationsController', conversationsController);

    conversationsController.$inject = ['conversationsService', '$scope', '$location'];

    function conversationsController(conversationsService, scope, location) {

        var vm = this;
        vm.getUserConversations = getUserConversations;
        vm.userConversations = [];
        getUserConversations();
        vm.imagePath = 'https://images-na.ssl-images-amazon.com/images/G/01/img15/pet-products/small-tiles/23695_pets_vertical_store_dogs_small_tile_8._CB312176604_.jpg';
        function getUserConversations() {
            conversationsService.userConversations().
                then(function (result) {
                    vm.userConversations = result.data;
                });
        }
    }
})();