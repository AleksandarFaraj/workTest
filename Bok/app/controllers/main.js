angular.module("bokio").controller("EnterBankLog", function ($scope,$http,$state) {
    $scope.enterBankLog = function (bankLog) {
        $http.post("api/BankLog", { BankLogString: bankLog }).then(function (entries) {
            $scope.entries = entries.data;
            console.log(entries.data);
            entries.data.forEach(function (entry) {
                if (entry.state !== "FINE") {
                    alert("this should be a nice modal with a tutorial on what to do when there is a duplicate or broken entry");
                    return;
                }
            });          
        }, function () {
            alert("Modal to show what to copy paste");
        });
    };
    $scope.postEntries = function (entries) {
        var filteredEntries = entries.filter(function (entry) {
            return entry.state === "FINE";
        });
        console.log(filteredEntries);
        $http.post("api/BankEntry", filteredEntries).then(function () {
            $state.go("ShowAllTransactions");
        });
    }
});

angular.module("bokio").controller("ShowAllTransactions", function ($scope, entries) {
    $scope.entries = entries.data;
});