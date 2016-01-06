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
            return <span key={url} onClick={this.handleClick}>{url}</span>;
        }, this);

        return (
            <div>
                <span className="selected" >{this.props.selectedUrl}</span>
                <div className="options">
                    {options}
                </div>
            </div>
        );
    },

    handleClick: function (e) {
        this.props.onChange(e.target.value);
    }
});

module.exports = AddressBarComponent;