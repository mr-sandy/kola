var React = require('react');
var ReactDOM = require('react-dom');

var ValueType = (props) => {
    return <span className={props.selected ? "selected" : ""} onClick={props.handleSelect}>{props.name}</span>;
}

var DropDown = (props) => {
    return (
        <div>
            {props.valueTypes.map(function(valueType) {
            return <ValueType key={valueType} name={valueType} selected={valueType.toUpperCase() === props.currentValue.toUpperCase()} handleSelect={props.handleSelect} />;
            })}
        </div>);
}

var TestComponent = React.createClass({

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

        var dropDown = null;

        if (this.state.expanded) {
            var valueTypes = ["Fixed", "Inherited"];
            dropDown = <DropDown currentValue={this.props.currentValue} valueTypes={valueTypes} handleSelect={this.handleSelect} />;
        };

        return (
            <div onClick={this.handleClick}>
                <span className="currentValue">{this.props.currentValue}</span>
                <button><i className={this.state.expanded ? "fa fa-angle-double-up" : "fa fa-angle-double-down"}></i></button>
                {dropDown}
            </div>);
    }
});

module.exports = TestComponent;
