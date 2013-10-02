define([
    'app/models/Component',
    'app/collections/Components'
], function (
    Component,
    Components) {
    'use strict';

    return Backbone.Model.extend(
    {
        initialize: function () {
            this.set('components', new Components());
            this.get('components').url = this.url + '/_components';
        },

        parse: function (resp, xhr) {

            var components = _.map(resp.components, function (value, index) {
                return new Component(_.extend(value, { id: index }), {});
            });

            this.get('components').reset(components);

            return _.omit(resp, 'components');
        }
    });
});