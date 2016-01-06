var classNames = require('classNames');
var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

var AddressBarComponent = React.createClass({
    propTypes: {
        selectedUrl: React.PropTypes.string.isRequired,
        candidateUrls: React.PropTypes.array.isRequired,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        const options = this.props.candidateUrls.map(function (url) {
            return <li key={url}><span onClick={this.handleClick}>{url}</span><a href={url} target="_blank"><i className="fa fa-external-link"></i></a></li>;
        }, this);

        const optionsClassNames = classNames('options', { 'expanded': this.state.expanded });

        return (
            <div>
                <span className="selected" onClick={this.handleToggleClick}>{this.props.selectedUrl}<i className="fa fa-caret-down"></i></span>
                <ul className={optionsClassNames}>
                    {options}
                </ul>
            </div>
        );
    },

    getInitialState: function () {
        return {
            expanded: false
        };
    },

    handleToggleClick: function (e) {
        e.stopPropagation();
        this.setState({
            expanded: !this.state.expanded
        });
    },

    handleClick: function (e) {
        e.stopPropagation();
        this.props.onChange(e.target.textContent);
    }
});

module.exports = AddressBarComponent;