angular.module('bokio', ['ui.router'])
.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    //I don't know how to configure the server to always redirect to index.html :-p
    // $locationProvider.html5Mode(true);

    $urlRouterProvider.otherwise("/");

    $stateProvider
      .state('LandingPage', {
          url: "/",
          templateUrl: "app/partials/LandingPage.html",
      })
      
      .state('EnterBankLog', {
          url: "/EnterBankLog",
          templateUrl: "app/partials/EnterBankLog.html",
          controller: "EnterBankLog"
      })

      .state('ShowAllTransactions', {
          url: "/ShowAllTransactions",
          templateUrl: "app/partials/ShowAllTransactions.html",
          controller: "ShowAllTransactions",
          resolve: {
              entries: function ($http) {
                  return $http.get("api/BankEntry");
              }
          }
      });
    
});

