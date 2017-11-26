import React, { Component } from 'react';
import Header from './Header';
import Value from './Value';

const style = selected => ({
    padding: selected ? '10px' : '10px 10px 0 10px',
    margin: '8px',
    borderRadius: '4px',
    backgroundColor: selected ? '#777' : 'transparent'
});

class Property extends Component {

    render() {
        const { property, onSelect } = this.props;

        return (
            <div style={style(property.selected)} className="property" onKeyUp={e => this.handleKeyUp(e)} onClick={onSelect}>
                <Header {...this.props} />
                <Value {...this.props} />
            </div>
        );
            }

    handleKeyUp(e) {
        if (e.which === 27){
            this.props.onDeselect();
        }
    }
}

export default Property;
