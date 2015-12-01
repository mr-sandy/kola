var React = require('react');
var ReactDOM = require('react-dom');

var ValueType = (props) => {
    return <span className={props.selected ? "selected" : ""} onClick={props.handleSelect}>{props.name}</span>;
}

var DropDown = (props) => {
    var divClass = (props.expanded) ? "dropdown expanded" : "dropdown";

    return (
        <div className={divClass}>
            {props.valueTypes.map(function(valueType) {
            return <ValueType key={valueType} name={valueType} selected={valueType.toUpperCase() === props.currentValue.toUpperCase()} handleSelect={props.handleSelect} />;
            })}
        </div>);
}

var PropertyValueTypeComponent = React.createClass({

    getInitialState: function () {
        return { expanded: false };
    },

    handleClick: function () {
        this.setState({ expanded: !this.state.expanded });
    },

    handleSelect: function (e) {
        this.props.handleSelect(e.target.textContent.toLowerCase());
    },

    render: function () {

        var valueTypes = ["Fixed", "Inherited"];

        return (
            <div className="valueType" onClick={this.handleClick}>
                <span className="currentValue">{this.props.currentValue}</span>
                <button><i className={this.state.expanded ? "fa fa-angle-double-up" : "fa fa-angle-double-down"}></i></button>
                <DropDown expanded={this.state.expanded} currentValue={this.props.currentValue} valueTypes={valueTypes} handleSelect={this.handleSelect} />
            </div>);
    }
});

module.exports = PropertyValueTypeComponent;
