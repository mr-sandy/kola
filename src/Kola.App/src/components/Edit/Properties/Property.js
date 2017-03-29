import React, { Component } from 'react';
import ValueType from './ValueType';
import Button from '../Button';
import Value from './Value';

const styles = {
    outer: {
        padding: '10px 10px 0 10px',
        margin: '8px',
        borderRadius: '4px'
    },
    outerSelected: {
        padding: '10px',
        backgroundColor: '#777'
    },
    name: {
        textTransform: 'capitalize',
        verticalAlign: 'sub'
    },
    chrome: {
        height: '18px'
    },
    resetButton: {
        normal: {
            borderWidth: '0',
            backgroundColor: '#ccc',
            borderRadius: '2px',
            marginTop: '8px',
            padding: '2px 6px',
            fontSize: '11px'
        },
        hover: {
            backgroundColor: '#ddd'
        }
    }
};

class Property extends Component {
    render() {
        const { name, selected, onClick } = this.props;

        const outerStyle = selected ? { ...styles.outer, ...styles.outerSelected } : styles.outer;

        return (
            <div style={outerStyle} className="property" onKeyUp={e => this.handleKeyUp(e)} onClick={() => onClick() }>
                <div style={styles.chrome} >
                    <span style={styles.name}>{name}</span>
                    <ValueType {...this.props} />
                </div>
                <Value {...this.props} selected={selected} />
                { selected
                    ? <Button styles={styles.resetButton} title="Reset" caption="reset" onClick={() => console
                        .log('clicked')} />
                    : false
                }
            </div>
        );
    }

    handleKeyUp(e) {
        if (e.which === 27) { // && this.state.editMode) {
            console.log('CANCEL#########');
            //this.processOutcomeOnce(Outcomes.cancel);
        }
    }
}

export default Property;