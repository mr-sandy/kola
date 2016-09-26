import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

const Property = props => {
    const { property } = props;



    return (<div className="property">
        <span style={{display: 'block'}}>Name: {property.name}</span>
        <span style={{display: 'block'}}>Type: {property.type}</span>
        <span style={{display: 'block'}}>Value Type: {property.value ? property.value.type: 'unset'}</span>
    </div>);
}

class Properties extends Component {
    render() {
        const { component } = this.props;
        const properties = component.properties || [];
        return (
            <div className="properties">
                { properties.map((p, i) => <Property key={i} property={p} />) }
            </div>
        );
    }
}

export default Properties;


//  this.editor = _.find(kola.propertyEditors, function (ed) {
//             return ed.propertyType === propertyType;
//         });

//              this.editor.render({
//                 element: this._element,
//                 value: this.props.propertyValue.value,
//                 editMode: this.props.editMode,
//                 onChange: this.handleChange,
//                 onCancel: this.props.onCancel
//             });