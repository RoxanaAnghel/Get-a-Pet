(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('conversationController', conversationController);

    conversationController.$inject = ['conversationService', '$scope', '$location'];

    function conversationController(conversationService, scope, location) {

        var vm = this;
        
    }
})();