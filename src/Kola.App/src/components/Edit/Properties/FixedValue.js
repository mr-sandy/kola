import React, { Component } from 'react';

class FixedValue extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const divClasses = 'value ' + this.props.type;

        return (
            <div className={divClasses} ref={el => this.el = el} onClick={e => this.handleClick(e)}>
            </div>
        );
    }

    componentDidMount() {
        this.componentDidUpdate();
    }

    componentDidUpdate() {
        if (!this.editor || this.editor.propertyType !== this.props.type) {
            this.editor = window.kola.propertyEditors.find(e => e.propertyType === this.props.type);

            if (!this.editor) {
                console.log('No editor for property type ' + this.props.type);
            }
        }

        if (this.editor) {
            this.editor.render({
                element: this.el,
                value: this.props.value ? this.props.value.value : '',
                editMode: this.props.selected,
                onChange: value => this.handleChange(value),
                onCancel: () => this.handleCancel()
            });
        }
    }

    handleChange(value) {
        this.props.onChange({
            type: 'fixed',
            value: value
        });
    }

    handleClick(e) {
        if (this.props.selected) {
            e.stopPropagation();
        }
    }

    handleCancel() {
        alert('cancelled');
    }
}

export default FixedValue;