import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

class Toolbox extends Component {
    render() {
        const { components = []} = this.props;

        return (
            <div>
                <h2>Toolbox</h2>
                <ul>
                    { components.map((t, i) => <li key={i}>{t.name}</li>) }
                </ul>
            </div>
        );
    }
}

Toolbox.PropTypes = {
    components: PropTypes.arrayOf(
        PropTypes.shape({
            name: React.PropTypes.string.isRequired
        })
    ).isRequired
}


const mapStateToProps = state => ({
    components: state.components
});

Toolbox = connect(
    mapStateToProps
)(Toolbox);

export default Toolbox;
