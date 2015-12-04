var React = require('react');

module.exports = React.createClass({

    render: function () {
        return (
                <div className="controls clearfix">
                    <button className="submit" onClick={this.handleSubmit}><i className="fa fa-check"></i></button>
                    <button className="cancel" onClick={this.handleCancel}><i className="fa fa-times"></i></button>
                </div>
            );
    },

    handleSubmit: function() {
        
    },

    handleCancel: function() {
        
    }
});



