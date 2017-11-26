import React, { Component } from 'react';

class FixedValue extends Component {
    render() {
        const { property } = this.props;

        const divClasses = 'value ' + property.type;

        return (
            <div className={divClasses} ref={el => this.el = el} onClick={e => this.handleClick(e)}>
            </div>
        );
    }

    componentDidMount() {
        this.componentDidUpdate();
    }

    componentDidUpdate() {
        const { property } = this.props;

        if (!this.editor || this.editor.propertyType !== property.type) {
            this.editor = window.kola.propertyEditors.find(e => e.propertyType === property.type);

            if (!this.editor) {
                console.log('No editor for property type ' + property.type);
            }
        }

        if (this.editor) {
            this.editor.render({
                element: this.el,
                value: property.value ? property.value.value : '',
                editMode: property.selected,
                onChange: value => this.handleChange(value),
                onCancel: () => this.handleCancel()
            });
        }
    }

    handleChange(value) {
        const { onChange } = this.props;

        onChange({
            type: 'fixed',
            value: value
        });
    }

    handleClick(e) {
        const { property } = this.props;

        if (property.selected) {
            e.stopPropagation();
        }
    }

    handleCancel() {
        alert('cancelled');
    }
}

export default FixedValue;