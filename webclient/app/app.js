'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
  'ngRoute',
  'LocalStorageModule',
  'myApp.public.home',
  'myApp.public.whoAmI',
  'myApp.secured',
]).

factory('tokenInjector', ['localStorageService', function(localStorageService) {  
    var tokenInjector = {
        request: function(config) {
            config.headers['Authorization'] = 'Bearer ' + localStorageService.get('id_token');
            return config;
        }
    };
    return tokenInjector;
}]).

config(['$routeProvider', '$httpProvider', function($routeProvider, $httpProvider) {

  // Register Http Interceptor which sents the token for each request
  $httpProvider.interceptors.push('tokenInjector');

  // Register callback route
   $routeProvider.
      when('/auth/login/:data', {
        template: '',
        controller: ['$routeParams', 'localStorageService', '$location', function ($routeParams, localStorageService, $location) {

          // It's always nice to have the original response somewhere
          console.debug('oidc-angular: handling login-callback', $routeParams.data);

          // parse the encoded data to get a key-value representation
          var parsed = parseQueryString($routeParams.data);

          // store id_token in localStorage
          localStorageService.set('id_token', parsed['id_token']);

          // Redirect to home
          $location.path('/');
      }]
    });        

  // Default route
  $routeProvider.otherwise({redirectTo: '/home'});

}]).

run(['$rootScope', '$window', function($rootScope, $window) {
  
  // Some OAuth config
  var authorizationUri = 'http://identity.amazing.ctd/connect/authorize';
  var requestScopes = 'openid profile';
  var responseType = 'id_token';

  // Specific Client Details
  var clientId = 'myAppId1234567890'; 
  var loginRedirectUri = 'http://webapp.amazing.ctd:8000/#/auth/login/';

  $rootScope.login = function() {

    var url = authorizationUri

              + "?response_type="
              + encodeURIComponent(responseType)
              
              + "&client_id=" 
              + encodeURIComponent(clientId) 
              
              + "&redirect_uri=" 
              + encodeURIComponent(loginRedirectUri) 
              
              + "&scope=" 
              + encodeURIComponent(requestScopes)
              
              + "&nonce=" 
              + encodeURIComponent('RandomNonce')
              
              + "&state=" 
              + encodeURIComponent('RandomState')
              ; 

    $window.location.href = url;
  };
}])
;