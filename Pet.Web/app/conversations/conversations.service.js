(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('conversationsService', conversationsService);

    conversationsService.$inject = ['$http'];

    function conversationsService($http) {

        this.userConversations = userConversations;
        this.getConversation = getConversation;

        function userConversations() {
            return $http({
                method: 'GET',
                url: '/api/conversations/user'
            });
        }

        function getConversationMessages(conversationId) {
            return $http({
                method: 'GET',
                url: '/api/conversations/messages/' + conversationId
            });
        }

        function getConversation(conversationId) {
            return $http({
                method: 'GET',
                url: '/api/conversations/' + conversationId
            });
        }
    }
})();