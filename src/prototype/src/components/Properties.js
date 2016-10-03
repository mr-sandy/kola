import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

const renderValue = (el, editor, property) => {
    if (property.value && property.value.value) {
        editor.render({
            element: el,
            value: property.value.value,
            editMode: false,
            onChange: () => { },
            onCancel: () => { }
        });
    }
}

class Property extends Component {
    render() {
        const { property, onPropertySelect, isSelected } = this.props;

        const editor = kola.propertyEditors.find(ed => ed.propertyType === property.type);
        const classNames = isSelected ? 'property selected' : 'property';

        return (<div className={classNames} onClick={() => onPropertySelect(property) }>
            <span style={{ display: 'block' }}>Name: {property.name}</span>
            <span style={{ display: 'block' }}>Type: {property.type}</span>
            <span style={{ display: 'block' }}>Value Type: {property.value ? property.value.type : 'unset'}</span>
            <div ref={ el => this.element = el}></div>
        </div>);
    }

    componentDidMount() {
        this.componentDidUpdate();
    }

    componentDidUpdate() {
        const { property, isSelected } = this.props;

        this.editor = kola.propertyEditors.find(ed => ed.propertyType === property.type);

        if (!this.editor) {
            console.log('No editor for property type ' + property.type);
        }

        if (this.editor && property.value && property.value.value) {
            this.editor.render({
                element: this.element,
                value: property.value.value,
                editMode: isSelected,
                onChange: () => { alert('ok') },
                onCancel: () => { alert('cancel') }
            });
        }
    }
}

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