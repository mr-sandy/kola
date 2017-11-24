import React, { Component } from 'react';

class InheritedValue extends Component {
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

    render() {
        const { value, selected } = this.props;
        const key = value ? value.key : '';

        return (
            <div className="value">
                {selected
                    ? (
                        <form>
                            <input ref={el => this.el = el } type="text" value={key} onChange={e => this.handleChange(e.target.value)} onBlur={e => console.log('blur!')} />
                        </form>
                    )
                    : <span>{key}</span>
                }
            </div>
        );
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
}

export default InheritedValue;