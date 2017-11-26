import React, { Component } from 'react';

class InheritedValue extends Component {
    render() {
        const { property } = this.props;
        const { value, selected } = property;
        const key = value ? value.key : '';

        return (
            <div className="value">
                {selected
                    ? (
                        <form>
                            <input
                                ref={el => this.el = el}
                                type="text"
                                value={key}
                                onChange={e => this.handleChange(e.target.value)}
                                onBlur={e => this.handleBlur(e.target.value)} />
                        </form>
                    )
                    : <span>{key}</span>
                }
            </div>
        );
    }

    componentDidMount() {
        if (this.el) {
            this.el.focus();
        }
    }

    componentDidUpdate() {
        if (this.el) {
            this.el.focus();
        }
    }

    handleCancel() {
        alert('cancelled');
    }

    handleChange(key) {
        this.props.onValueChange({
            type: 'inherited',
            key: key
        });
    }

    handleBlur(key) {
        this.props.onChange({
            type: 'inherited',
            key: key
        });
    }

}

export default InheritedValue;