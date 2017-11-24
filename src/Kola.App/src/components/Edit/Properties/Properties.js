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
        const { showProperties, properties, selectProperty, setProperty, componentPath, setPropertyValueType, setPropertyValue } = this.props;

        return (
            <Toolbar style={styles.toolbar(showProperties)}>
                <ToolbarContent style={styles.content}>
                    {properties.map(p => (
                        <Property
                            key={p.name}
                            property={p}
                            onValueTypeChange={setPropertyValueType}
                            onValueChange={setPropertyValue}
                            onChange={val => setProperty(componentPath, p.name, val)}
                            onSelect={() => selectProperty(p)}
                            onDeselect={() => selectProperty()} />
                    ))}
                </ToolbarContent>
                <ToolbarButtonTray>
                    <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon='fa-cog' active={false} />
                </ToolbarButtonTray>
            </Toolbar>
        );
    }
}

export default Properties;