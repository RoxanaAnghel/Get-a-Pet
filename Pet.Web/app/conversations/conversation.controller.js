(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('conversationController', conversationController);

    conversationController.$inject = ['conversationsService', 'messagesService', '$scope', '$location','$routeParams'];

    function conversationController(conversationsService, messagesService, scope, location, $routeParams) {

        var vm = this;
        vm.messages = [];
        vm.loadMessages = loadMessages;

        vm.conversation = $routeParams.conversationId;
        vm.currentText = "";
        loadMessages();

        vm.sendMessage = sendMessage;

        function loadConversation() {

        }

        function loadMessages() {
            messagesService.getMessages($routeParams.conversationId).
                then(function (result) {
                    vm.messages = result.data;
                });
        }

        function sendMessage() {
            console.log("in mesaj");
            if (vm.currentText) {
                var message = {
                    ConversationId: vm.conversation,
                    Text:vm.currentText
                };
                messagesService.sendMessage(message).
                    then(function (result) {
                        loadMessages();
                    });
            }
        }

        //setInterval(loadMessages, 100);
    }
})();