define([
    'backbone',
    'underscore',
    'app/models/ComponentCollection'
], function (Backbone,
    _,
    ComponentCollection) {
    
    "use strict";

    return Backbone.Model.extend({

        initialize: function () {
            this.set({ components: new ComponentCollection() });
        },

        parse: function (resp, xhr) {
            this.get("components").refresh(resp.components);

            return _.omit(resp, "components");
        },

        url: function () {
            return "/_kola/templates/" + this.get("id");
        }
    });
});

//    return Backbone.Model.extend({

//        initialize: function () {
//            this.set({ components: new Components() });
//            this.on("componentAdded", function () { alert("oh my!"); });
//        },

//        addComponent: function (component) {
//            var self = this;
//            this.get("components").add(component);
//            component.save()
//                .then(function () {
//                    self.trigger("componentAdded", "an event");
//                });
//        },

//        url: function () {
//            return "/_kola/templates/" + this.get("id");
//            //            return this.combineUrls(config.rootUrl, '/demos');
//        },

//        componentsUrl: function () {
//            return this.url() + "/_components";
//        },

//        parse: function (resp, xhr) {
//            return resp;
//            //            return {
//            //                components: _.map(resp.components, this.makeComponent)
//            //            };
//        },

//        makeComponent: function (value, key, list) {
//            var component = new Component();
//            component.parse(value);
//            this.get("components").add(component);
//        }
//    });