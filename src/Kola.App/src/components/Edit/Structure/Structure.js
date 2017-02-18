import React, { Component } from 'react';
import ComponentList from './ComponentList';
import Toolbar from '../Toolbar';
import ToolbarContent from '../ToolbarContent';
import ToolbarButtonTray from '../ToolbarButtonTray';
import Button from '../Button';

const styles = {
    base: {
        width: '250px'
    },  
    content: {
        padding: '10px'
    }
}

class Structure extends Component {
    render() {
        const { components = [], ...otherProps } = this.props;
        const { placeholderPath, showPlaceholder, selectedComponent } = otherProps;
        return (
            <Toolbar style={styles.base}>
                <ToolbarContent style={styles.content}>
                    <ComponentList 
                        components={components} 
                        componentPath="/" 
                        placeholderPath={placeholderPath} 
                        showPlaceholder={p => showPlaceholder(p) } 
                        style={{ minHeight: '100%' }} 
                        onAddComponent={e => this.handleAddComponent(e)} 
                        onMoveComponent={e => this.handleMoveComponent(e)} 
                        {...otherProps} />
                </ToolbarContent>
                <ToolbarButtonTray>
                    <Button title="Duplicate Component" onClick={() => this.handleDuplicateComponent()} icon="fa-files-o" active={false} enabled={selectedComponent ? true : false} />
                    <Button title="Delete Component" onClick={() => this.handleRemoveComponent()} icon="fa-trash" active={false} enabled={selectedComponent ? true : false} />
                </ToolbarButtonTray>
            </Toolbar>
        );
    }

    handleAddComponent(e) {
        this.props.addComponent(e.componentPath, e.componentType);
    }

    handleMoveComponent(e) {
        if (e.sourcePath !== e.targetPath) {
            this.props.moveComponent(e.sourcePath, e.targetPath);
        }
    }

    handleRemoveComponent() {
        const { removeComponent, selectedComponent } = this.props;
        if (selectedComponent) {
            removeComponent(selectedComponent);
        }
    }

    handleDuplicateComponent() {
        const { duplicateComponent, selectedComponent } = this.props;
        if (duplicateComponent) {
            duplicateComponent(selectedComponent);
        }
    }
}

export default Structure;
