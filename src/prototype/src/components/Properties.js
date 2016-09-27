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
        const { property } = this.props;

        const editor = kola.propertyEditors.find(ed => ed.propertyType === property.type);

        return (<div className="property">
            <span style={{ display: 'block' }}>Name: {property.name}</span>
            <span style={{ display: 'block' }}>Type: {property.type}</span>
            <span style={{ display: 'block' }}>Value Type: {property.value ? property.value.type : 'unset'}</span>
            <div ref={ el => this.element = el}></div>
        </div>);
    }

    componentDidMount() {
        const { property } = this.props;

        this.editor = kola.propertyEditors.find(ed => ed.propertyType === property.type);

        if (!this.editor) {
            console.log('No editor for property type ' + property.type);
        }

        this.componentDidUpdate();
    }

    componentDidUpdate() {
        const { property } = this.props;

        if (this.editor && property.value && property.value.value) {
            this.editor.render({
                element: this.element,
                value: property.value.value,
                editMode: false,
                onChange: () => { },
                onCancel: () => { }
            });
        }
    }
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



//              this.editor.render({
//                 element: this._element,
//                 value: this.props.propertyValue.value,
//                 editMode: this.props.editMode,
//                 onChange: this.handleChange,
//                 onCancel: this.props.onCancel
//             });