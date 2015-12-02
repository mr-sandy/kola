var PropertyValueTypeComponent = require('app/components/PropertyValueTypeComponent.jsx');
var FixedPropertyValueComponent = require('app/components/FixedPropertyValueComponent.jsx');
var React = require('react');
var ReactDOM = require('react-dom');

var PropertyName = (props) => {
    return <label className="name">{props.name}</label>;
}

var PropertyComponent = React.createClass({

    getInitialState: function () {
        return { editMode: false };
    },

    render: function () {

        var divClass = this.state.editMode
        ? "property editMode"
        : "property";

        return (
            <div className={divClass} onClick={this.handleEdit}>
                <div className="chrome">
                    <PropertyName name={this.props.propertyName}  />
                    <PropertyValueTypeComponent currentValue={this.props.propertyValue.type} />
                </div>
                <FixedPropertyValueComponent ref={this.captureValueElement} editMode={this.state.editMode} propertyType={this.props.propertyType} propertyValue={this.props.propertyValue.value} />
                <div className="controls">
                    <button className="submit" onClick={this.handleSubmit}><i className="fa fa-check"></i></button>
                    <button className="cancel" onClick={this.handleCancel}><i className="fa fa-times"></i></button>
                    <div style={{clear:"both"}}></div>
                </div>
            </div>
            );
    },

    captureValueElement: function(el) {
        this._fixedValue = el;
    },

    handleEdit: function () {
        if (!this.state.editMode) {
            this.setState({ editMode: true });
        }
    },

    handleSubmit: function () {
        if (this.state.editMode) {
            alert(this._fixedValue.value());
            this.setState({ editMode: false });
        }
    },

    handleCancel: function () {
        if (this.state.editMode) {
            this.setState({ editMode: false });
        }
    }
});

module.exports = PropertyComponent;
