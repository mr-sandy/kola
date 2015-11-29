var React = require('react');
var ReactDOM = require('react-dom');

class TestComponent extends React.Component {
    handleClick() {
        alert("click");
    }

    render() {
        return (
            <div>
                <span className="currentValue">Fixedy</span>
                <button onClick={this.handleClick}><i className="fa fa-angle-double-down"></i></button>
                <div>
                    <span className="valueTypeOption selected">Fixed</span>
                    <span className="valueTypeOption">Inherited</span>
                </div>
            </div>
        )
    }
}

module.exports = TestComponent;

