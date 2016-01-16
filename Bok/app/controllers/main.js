angular.module("bokio").controller("main", function ($scope,$http) {
    $scope.enterBankLog = function (bankLog) {
        $http.post("api/BankLog", { BankLogString: bankLog }).then(function (entries) {
            $scope.entries = entries.data;
            console.log(entries.data);
        });
    };
});