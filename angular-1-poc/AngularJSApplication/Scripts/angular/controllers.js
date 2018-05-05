app.controller("NavCtrl", function ($scope, $route) {
//    $scope.shownSection = 'ExternalAPIExample';
//    $scope.toggleSection = function (section) {
//        $scope.shownSection = section;
//    };
});

app.controller("ApiCtrl", function ($scope, $http) {
    $scope.query = "";
    $scope.queryInProgress = false;
    $scope.jsonResult = [];
    $scope.queryDbPedia = function () {
        console.log("DbPedia query in progress...");
        $scope.queryInProgress = true;
        $http.get('http://lookup.dbpedia.org/api/search/PrefixSearch?QueryClass=&MaxHits=50&QueryString=' + $scope.query)
            .success(function (data, status, headers, config) {
                console.log("GET request was successful.");
                $scope.jsonResult = data.results;
                $scope.queryInProgress = false;
                $scope.query = '';
            })
            .error(function (data, status, headers, config) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                console.log("Error!");
                console.log(data);
                console.log(status);
                console.log(headers);
                console.log(config);
            });
    };
});

app.controller("FormCtrl", function ($scope) {
    $scope.formData = [];
    $scope.formToJson = "";
    $scope.submitForm = function (newForm) {
        $scope.formData.push({
            name: newForm.name,
            age: newForm.age,
            hasPets: newForm.hasPets === "No" ? false : true
        });
        $scope.formToJson = angular.toJson($scope.formData);
    };
});

app.controller("DirectiveCtrl", function ($scope) {
    $scope.titleColor = "hsla(225, 55%, 95%, 1)";
    $scope.toggle = false;    
});