import React, { Component } from 'react';
import Button from '../Button';
import Toolbar from '../Toolbar';
import ToolbarContent from '../ToolbarContent';
import ToolbarButtonTray from '../ToolbarButtonTray';
import Property from './Property';

const styles = {
    toolbar: visible => ({
        color: '#eee',
        width: visible ? '242px' : '0'
    }),
    content: {
        padding: '0'
    }
}

class Properties extends Component {
    render() {
        const { showProperties, properties } = this.props;

        return (
            <Toolbar style={styles.toolbar(showProperties)}>
                <ToolbarContent style={styles.content}>
                    {properties.map(p => (
                        <Property key={p.name}
                            property={p}
                            onSelect={() => this.handleSelect(p.name)}
                            onDeselect={() => this.handleDeselect()}
                            onChange={val => this.handleChange(p.name, val)} />
                    ))}
                </ToolbarContent>
                <ToolbarButtonTray>
                    <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon='fa-cog' active={false} />
                </ToolbarButtonTray>
            </Toolbar>
        );
    }

    handleSelect(name) {
        const { selectProperty } = this.props;
        selectProperty(name);
    }

    handleDeselect() {
        const { selectProperty } = this.props;
        selectProperty();
    }

    handleChange(name, value) {
        const { setProperty, componentPath } = this.props;
        setProperty(componentPath, name, value);
    }
}

export default Properties;