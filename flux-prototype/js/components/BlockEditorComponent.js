var React = require('react');
var PureRenderMixin = require('react/addons').addons.PureRenderMixin;
var EditorActionCreators = require('../actions/EditorActionCreators');

function getChildren(component) {
    return component.get('components') || component.get('areas') || [];
}

var BlockEditorComponent = React.createClass({

    mixins: [PureRenderMixin],

    render: function () {
        switch (this.props.component.get('type')) {
            case 'atom':
                return this._renderWithoutChildren();

            default :
                return this._renderWithChildren();
        }
    },

    _renderWithoutChildren: function () {
        var classes = [];

        if(this.props.component.get('selected'))
        {
            classes.push('selected');
        }

        return (
            <li className={classes.join(' ')}
                data-path={this.props.component.get('path')}
                onClick = {this._onItemClick}>
                <span className="chrome">{this.props.component.get('type')} - {this.props.component.get('name')} - {this.props.component.get('sandy')}</span>
            </li>
        );
    },

    _renderWithChildren: function () {
        var components = getChildren(this.props.component).map(function (component) {
            return (
                <BlockEditorComponent key={component.get('path')} component={component}/>
            );
        });

        var classes = [];

        if(this.props.component.get('collapsed'))
        {
            classes.push('collapsed');
        }

        if(this.props.component.get('selected'))
        {
            classes.push('selected');
        }

        return (
            <li className={classes.join(' ')}
                data-path={this.props.component.get('path')}
                onClick = {this._onItemClick}>
                <span className="chrome">{this.props.component.get('type')} - {this.props.component.get('name')} - {this.props.component.get('sandy')}
                    <button
                        className="collapse"
                        onClick={this._onCollapseClick}>
                        <i className="fa fa-chevron-down"></i>
                    </button>
                </span>
                <ol>
                    {components}
                </ol>
            </li>
        );
    },

    _onCollapseClick: function (e) {
        e.stopPropagation();

        if (this.props.component.get('collapsed')) {
            EditorActionCreators.expandComponent(this.props.component);
        }
        else {
            EditorActionCreators.collapseComponent(this.props.component);
        }
    },

    _onItemClick: function (e) {
        e.stopPropagation();

        if (this.props.component.get('selected')) {
            EditorActionCreators.deselectComponent(this.props.component);
        }
        else {
            EditorActionCreators.selectComponent(this.props.component);
        }
    }
});

module.exports = BlockEditorComponent;