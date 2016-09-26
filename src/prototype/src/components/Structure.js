import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

const Element = props => {
    const { component, onClick, selectedComponent } = props;
    const children = component.areas || component.components || [];

    const handleClick = e => {
        if (component.type !== 'area') {
            e.stopPropagation();
            onClick(component);
        }
    }

    const classNames = component === selectedComponent
        ? 'component selected'
        : 'component';

    return (
        <div className={classNames} onClick={handleClick}>
            <span>{component.type}: {component.name} ({component.path}) </span>
            { children.map((component, i) => <Element key={i} component={component} onClick={onClick} selectedComponent={selectedComponent} />) }
        </div>
    );
}

class Structure extends Component {
    render() {
        const { template, onClick, selectedComponent } = this.props;
        const components = template.components || [];

        return (
            <div className="structure">
                { components.map((component, i) => <Element key={i} component={component} onClick={onClick} selectedComponent={selectedComponent} />) }
            </div>
        );
    }
}

export default Structure;
