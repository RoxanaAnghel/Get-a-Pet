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
        function getUserConversations() {
            conversationsService.userConversations().
                then(function (result) {
                    vm.userConversations = result.data;
                });
        }
    }
})();