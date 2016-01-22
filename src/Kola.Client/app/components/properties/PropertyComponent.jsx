var PropertyHeaderComponent = require('app/components/properties/PropertyHeaderComponent.jsx');
var PropertyValueComponent = require('app/components/properties/PropertyValueComponent.jsx');
var classNames = require('classNames');
var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

var ResetButton = (props) => {
    return <button className="reset" type="button" onClick={props.onClick}>reset</button>;
};

const Outcomes = {
    cancel: 'cancel',
    change: 'change',
    reset: 'reset'
};

var PropertyComponent = React.createClass({
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

        const divClass = classNames('property', { 'editMode': this.state.editMode, 'unset': !this.state.propertyValue });

        return (
            <div className={divClass} onClick={this.handleClick} onKeyUp={this.handleKeyUp}>
                <PropertyHeaderComponent {...childProps} onChange={this.handlePropertyValueTypeChange} />
                <PropertyValueComponent {...childProps} onChange={this.handlePropertyValueChange} onCancel={this.handleCancel} />
                {this.state.editMode ? <ResetButton onClick={this.handleReset} /> : false}
            </div>);
    },

    componentWillReceiveProps: function (nextProps) {
        this.setState({
            editMode: false,
            propertyValue: nextProps.propertyValue
        });
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

    handleClick: function (e) {
        e.stopPropagation();

        if (!this.state.editMode) {
            this.processOutcomeOnce = _.once(this.processOutcome);

            const propertyValue = this.state.propertyValue
                ? this.state.propertyValue
                : { type: 'fixed' };

            this.setState({
                editMode: true,
                propertyValue: propertyValue
            });
        } else {
            this.processOutcomeOnce(Outcomes.cancel);
        }
    },

    handleKeyUp: function (e) {
        if (e.which === 27 && this.state.editMode) {
            this.processOutcomeOnce(Outcomes.cancel);
        }
    },

    handlePropertyValueTypeChange: function (propertyValueType) {

        if (!this.state.propertyValue || this.state.propertyValue.type !== propertyValueType) {

            const propertyValue = this.props.propertyValue && propertyValueType === this.props.propertyValue.type
                ? this.props.propertyValue
                : { type: propertyValueType };

            this.setState({ propertyValue: propertyValue });
        }
    },

    handlePropertyValueChange: function (propertyValue) {
        if (this.valuesDiffer(this.props.propertyValue, propertyValue)) {
            this.processOutcomeOnce(Outcomes.change, propertyValue);
        } else {
            this.processOutcomeOnce(Outcomes.cancel);
        }
    },

    handleReset: function () {
        this.processOutcomeOnce(Outcomes.reset);
    },

    handleCancel: function () {
        //TODO {SC} This check seems to be required on 'esc'.  Establish why.
        if (this.processOutcomeOnce) {
            this.processOutcomeOnce(Outcomes.cancel);
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
    },

    processOutcome: function (outcome, propertyValue) {
        switch (outcome) {
            case Outcomes.change:
                this.props.onChange({
                    propertyName: this.props.propertyName,
                    propertyType: this.props.propertyType,
                    propertyValue: propertyValue
                });
                //this.setState({ editMode: false });
                break;

            case Outcomes.reset:
                this.props.onChange({
                    propertyName: this.props.propertyName,
                    propertyType: this.props.propertyType,
                    propertyValue: null
                });
                //this.setState({ editMode: false });
                break;

            case Outcomes.cancel:
                this.setState({
                    editMode: false,
                    propertyValue: this.props.propertyValue
                });
                break;
        }
    }
});

module.exports = PropertyComponent;