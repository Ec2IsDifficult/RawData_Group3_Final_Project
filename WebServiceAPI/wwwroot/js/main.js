﻿

require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        text: "lib/requirejs/text",
        Sammy: "lib/sammy/lib/min/sammy-0.7.6.min",
        bootstrap: "../css/lib/bootstrap/dist/js/bootstrap.bundle.min",
        dataservice: "services/dataservices",
        authservice: "services/authservices",
        userservice: "services/userservices",
        ApiConfig: "config/ApiConfig",
        AppConfig: "config/AppConfig",
    }
});

/**
 * Component registration
 */
require(['knockout'], (ko) => {

    let component_name = ["user-login", "user-recover", "user-register", "user-update-email"];
    component_name.forEach(registerComponent);

    function registerComponent(component_name) {
        ko.components.register(component_name, {
            viewModel: { require: "components/" + component_name + "/" + component_name },
            template: {
                require: "text!components/" + component_name + "/" + component_name + ".html"
            }
        });
    }

});




require(["knockout", "viewmodel"], function (ko, vm) {

    ko.applyBindings(vm);

});