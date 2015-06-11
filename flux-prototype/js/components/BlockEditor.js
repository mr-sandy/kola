var React = require('react');
var TemplateStore = require('../stores/TemplateStore.js');
var BlockEditorComponent = require('./BlockEditorComponent.js');
var PureRenderMixin = require('react/addons').addons.PureRenderMixin;

function getState() {
    return {
        template: TemplateStore.getTemplate()
    };
}

function getChildren(template) {
    return (template.get)
        ? template.get('components')
        : [];
}

var BlockEditor = React.createClass({

        mixins: [PureRenderMixin],

        getInitialState: function () {
            return getState();
        },

        componentDidMount: function () {
            TemplateStore.addChangeListener(this._onChange);
        },

        componentWillUnmount: function () {
            TemplateStore.removeChangeListener(this._onChange);
        },

        render: function () {

            var components = getChildren(this.state.template).map(function (component) {
                return (
                    <BlockEditorComponent key={component.get('path')} component={component}/>
                );
            });

            return (
                <div className="block-editor no-select">
                    <ol>
                        {components}
                    </ol>
                </div>
            );
        },

        _onChange: function () {
            this.setState(getState());
        }
    })
    ;

module.exports = BlockEditor;