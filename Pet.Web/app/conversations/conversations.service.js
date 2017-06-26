(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('conversationsService', conversationsService);

    conversationsService.$inject = ['$http'];

    function conversationsService($http) {

        this.userConversations = userConversations;

        function userConversations() {
            return $http({
                method: 'GET',
                url: '/api/conversations/user'
            });
        }
    }
})();