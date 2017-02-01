import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import Property from './Property';

class Properties extends Component {
    render() {
        const { component, onPropertySelect, selectedProperty } = this.props;
        const properties = component.properties || [];
        return (
            <div className="properties">
                { properties.map((p, i) => <Property key={i} isSelected={p === selectedProperty} onPropertySelect={onPropertySelect} property={p} />) }
            </div>
        );
    }
}

export default Properties;




//              this.editor.render({
//                 element: this._element,
//                 value: this.props.propertyValue.value,
//                 editMode: this.props.editMode,
//                 onChange: this.handleChange,
//                 onCancel: this.props.onCancel
//             });