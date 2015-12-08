var PropertyHeaderComponent = require('app/components/properties/PropertyHeaderComponent.jsx');
var PropertyValueComponent = require('app/components/properties/PropertyValueComponent.jsx');
var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

function ResetButton(props) {
    return <button className="reset" type="button" onClick={props.onClick}>reset</button>;
}

module.exports = React.createClass({
    propTypes: {
        onChange: React.PropTypes.func.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object
    },

    render: function () {

        const childProps = {
            editMode: this.state.editMode,
            propertyName: this.props.propertyName,
            propertyType: this.props.propertyType,
            propertyValue: this.state.propertyValue
        };

        const divClass = this.state.editMode ? 'property editMode' : 'property';

        return (
            <div className={divClass} onClick={this.handleClick} onKeyUp={this.handleKeyUp}>
                <PropertyHeaderComponent {...childProps} onChange={this.handlePropertyValueTypeChange} />
                <PropertyValueComponent {...childProps} onChange={this.handlePropertyValueChange} />
                {this.state.editMode ? <ResetButton onClick={this.handleReset} /> : false}
            </div>);
    },

    componentWillMount: function () {
        this.processChangeOnce = _.once(this.processChange);
    },

    componentDidMount: function () {
        $(document.body).on('keyup', this.handleKeyUp);
    },

    componentWillUnmount: function () {
        $(document.body).off('keyup', this.handleKeyUp);
    },

    getInitialState: function () {
        return {
            editMode: false,
            propertyValue: this.props.propertyValue
        };
    },

    handleClick: function () {
        if (!this.state.editMode) {

            var propertyValue = this.state.propertyValue
                ? this.state.propertyValue
                : { type: 'fixed' };

            this.setState({
                editMode: !this.state.editMode,
                propertyValue: propertyValue
            });
        }
    },

    handleKeyUp: function (e) {
        if (e.which === 27) {
            this.doCancel();
        }
    },

    handlePropertyValueChange: function (propertyValue) {
        if (this.valuesDiffer(this.props.propertyValue, propertyValue)) {
            this.processChangeOnce(propertyValue);
        } else {
            this.setState({ editMode: false });
        }
    },

    handleReset: function () {
        this.processChangeOnce(null);
    },

    processChange: function (propertyValue) {
        this.props.onChange({
            propertyName: this.props.propertyName,
            propertyType: this.props.propertyType,
            propertyValue: propertyValue
        });
    },

    handlePropertyValueTypeChange: function (propertyValueType) {

        if (!this.state.propertyValue || this.state.propertyValue.type !== propertyValueType) {

            const propertyValue = this.props.propertyValue && propertyValueType === this.props.propertyValue.type
                ? this.props.propertyValue
                : { type: propertyValueType };

            this.setState({ propertyValue: propertyValue });
        }
    },

    doCancel: function () {
        if (this.state.editMode) {
            this.setState({
                editMode: false,
                propertyValue: this.props.propertyValue
            });
        }
    },

    valuesDiffer: function (val1, val2) {

        if (!val1 || !val2) {
            return true;
        }

        if (val1.type !== val2.type) {
            return true;
        }

        if (val1.type === 'fixed' && val1.value !== val2.value) {
            return true;
        }

        if (val1.type === 'inherited' && val1.key !== val2.key) {
            return true;
        }

        return false;
    }
});
