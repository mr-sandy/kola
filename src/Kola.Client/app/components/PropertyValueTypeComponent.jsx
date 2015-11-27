var React = require('react');
var ReactDOM = require('react-dom');

class TestComponent extends React.Component {
  render() {
    return <div><span className="currentValueType">Fixed</span></div>
  }
}

module.exports = TestComponent;

//     <a href="#" onClick={this.props.handleClick}>Do something!</a>