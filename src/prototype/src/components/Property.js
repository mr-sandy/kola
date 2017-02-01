import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import { loadEditor } from './utility';
import classnames from 'classnames';

class Property extends Component {
    constructor(props) {
        super(props);
        this.state = {
            editMode: false
        };
    }

    componentDidMount() {
        this.componentDidUpdate();
    }

    componentDidUpdate() {
        const { property, isSelected } = this.props;

        const editor = loadEditor(property.type);

        if (editor && property.value && property.value.value) {
            editor.render({
                element: this.element,
                value: property.value.value,
                editMode: this.state.editMode,
                onChange: () => this.handleSubmit(),
                onCancel: () => this.handleCancel()
            });
        }
    }

    handleCancel() {
        this.setState({ editMode: false });
    }

    handleSubmit() {
        this.setState({ editMode: false });
    }

    handleClick() {
        const { property, onPropertySelect, isSelected } = this.props;

        if (!isSelected) {
            onPropertySelect(property);
        }
        else if (!this.state.editMode) {
            this.setState({ editMode: true });
        }
    }

    render() {
        const { property, isSelected } = this.props;

        return (
            <div className={classnames('property', { 'selected': isSelected }) } onClick={() => this.handleClick() }>
                <span style={{ display: 'block' }}>Name: {property.name}</span>
                <span style={{ display: 'block' }}>Type: {property.type}</span>
                <span style={{ display: 'block' }}>Value Type: {property.value ? property.value.type : 'unset'}</span>
                <div ref={ el => this.element = el}></div>
            </div>
        );
    }
}

Property.propTypes = {
    property: React.PropTypes.object,
    onPropertySelect: React.PropTypes.func.isRequired,
    isSelected: React.PropTypes.bool
};

export default Property;



//              this.editor.render({
//                 element: this._element,
//                 value: this.props.propertyValue.value,
//                 editMode: this.props.editMode,
//                 onChange: this.handleChange,
//                 onCancel: this.props.onCancel
//             });