//app.directive('sectionToggler', function () {
//    return {
//        restrict: 'E',
//        scope: false,
//        link: function (scope, element, attrs) {
//            element.bind('click', function () {
//                scope.$apply(function () {
//                    scope.toggleSection(attrs["toggle"]);
//                });
//            });
//        }
//    };
//});

app.directive('toggleIcon', function () {
    return {
        restrict: 'EA',
        scope: false,
        link: function (scope, element, attrs) {
            element.bind('click', function () {
                var colorIsToggled = scope.toggled;
                
                scope.$apply(function () {
                    if (!colorIsToggled) {
                        scope.toggled = true;
                        scope.titleColor = "hsla(360, 100%, 50%, 1)";
                        element.toggleClass("fa-toggle-off");
                        element.toggleClass("fa-toggle-on");
                    
                    }   else {
                        element.toggleClass("fa-toggle-off");
                        element.toggleClass("fa-toggle-on");
                        scope.toggled = false;
                        scope.titleColor = "hsla(225, 55%, 95%, 1)";
                    };
                       
                });
            });
        },
        template: '<i ng-style="{\'color\': titleColor}" class="fa fa-toggle-off fa-3x"></i>',
        replace: true
    }
});
