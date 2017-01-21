(function () {
    'use strict';

    angular.module('common.services', [
        // Angular modules 
        'ngResource'

        // Custom modules 

        // 3rd Party Modules

    ]).constant("appSettings", {
        serverPath: 'http://localhost:60823'
    });
})();