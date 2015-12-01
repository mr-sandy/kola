define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var _ = require('underscore');
    var Template = require('text!app/templates/PropertyTemplate.html');
    var propertyEditors = require('propertyEditors');

    require('jqueryui');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'div',

        className: 'property',

        initialize: function (options) {
            this.editMode = false;
            this.amendments = options.amendments;
            this.componentPath = options.componentPath;
        },

        events: {
            'click': 'edit',
            'submit': 'submit',
            'click .cancel': 'cancel',
            'keyup': function (e) {
                if (e.keyCode === 27) {
                    //Esc 
                    this.cancel();
                }
            }
        },

        render: function () {
            var context = _.extend(this.model, { editMode: this.editMode });

            this.$el.html(this.template(context));
            var $editorElement = this.$el.find('.value').last();

            this.loadEditor($editorElement).then($.proxy(this.renderEditor, this));

            if (this.model.value.type === 'fixed' && this.model.value.value === '' && !this.editMode) {
                this.$el.addClass('unset');
            } else {
                this.$el.removeClass('unset');
            }

            return this;
        },

        edit: function (e) {
            if (!this.editMode) {
                this.editMode = true;
                this.render();
            }
        },

        loadEditor: function ($editorElement) {
            var self = this;
            var d = $.Deferred();

            var propertyValue = this.model.value;
            var editorInfo = this.getEditorInfo(this.model.type);

            if (this.editorView) {
                this.editorView.setElement($editorElement);
                d.resolve();
            }
            else
                if (editorInfo) {
                    require([editorInfo.url], function (EditorView) {
                        self.editorView = new EditorView({
                            model: propertyValue,
                            el: $editorElement
                        });
                        self.editorView.on('submit', self.submit, self);
                        d.resolve();
                    });
                }
                else {
                    d.resolve();
                }

            return d.promise();
        },

        renderEditor: function () {
            if (this.editorView) {
                this.editorView.render(this.editMode);
                this.$('form.modal').resizable().draggable({ delay: 100 });

                // Ow! Ow! This stinks so badly it hurts
                var $editorEl = this.editorView.$el;
                setTimeout(function () {
                    $editorEl.find('input, select, textarea').first().focus();
                }, 100);
            }
        },

        getEditorInfo: function (propertyType) {
            return _.find(propertyEditors, function (propertyEditor) {
                return propertyEditor.name == propertyType;
            });
        },

        submit: function (e) {
            if (e) {
                e.preventDefault();
                e.stopPropagation();
            }

            if (this.editMode) {
                this.editMode = false;

                var newValue = this.editorView.value();

                if (newValue !== this.model.value.value) {
                    this.amendments.setProperty({
                        propertyName: this.model.name,
                        componentPath: this.componentPath,
                        value: newValue
                    });
                }
                else {
                    this.render();
                }
            }
        },

        cancel: function (e) {
            if (e) {
                e.preventDefault();
                e.stopPropagation();
            }

            if (this.editMode) {
                this.editMode = false;
                this.render();
            }
        }
    });
});