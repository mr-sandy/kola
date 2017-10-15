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
        const { property, onSelect, onDeselect, onChange } = this.props;
        const { selected, name, value, type } = property;

        return (
            <div style={style(selected)} className="property" onKeyUp={e => this.handleKeyUp(e)} onClick={onSelect}>
                <Header caption={name} value={value} selected={selected} onValueTypeChange={t => this.handleValueTypeChange(t)} />
                <Value type={type} value={value} selected={selected} onChange={v => this.handleValueChange(v)} />
            </div>
        );
            }

    handleKeyUp(e) {
        if (e.which === 27){
            this.props.onDeselect();
        }
    }

    handleValueTypeChange(t) {
        console.log(t);
    }

    handleValueChange(v) {
        console.log(v);
    }
}

export default Property;
