import React, { Component } from 'react';
import ComponentList from './ComponentList';
import Toolbar from '../Toolbar';
import ToolbarContent from '../ToolbarContent';
import ToolbarButtonTray from '../ToolbarButtonTray';
import Button from '../Button';
import { arraysMatch } from './helpers';

const styles = {
    base: {
        width: '250px'
    },  
    content: {
        padding: '10px'
    }
}

class Structure extends Component {
    state = {
        placeholderPath: []
    }

    setPlaceholderPath(placeholderPath) {
        if (!arraysMatch(placeholderPath, this.state.placeholderPath)) {
            this.setState({ placeholderPath });
        }
    }

    render() {
        const { components = [], ...otherProps } = this.props;
        return (
            <Toolbar style={styles.base}>
                <ToolbarContent style={styles.content}>
                    <ComponentList 
                        components={components} 
                        componentPath="/" 
                        placeholderPath={this.state.placeholderPath} 
                        setPlaceholderPath={p => this.setPlaceholderPath(p) } 
                        style={{ minHeight: '100%' }} 
                        onDrop={e => this.handleDrop(e)} 
                        {...otherProps} />
                </ToolbarContent>
                <ToolbarButtonTray>
                    <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon="fa-cog" active={false} />
                </ToolbarButtonTray>
            </Toolbar>
        );
    }

    handleDrop(e) {
        
        this.props.addComponent(this.props.templatePath, e.componentPath, e.componentType);
        this.props.selectComponent('/' + this.state.placeholderPath.join('/'));
        this.setState({ placeholderPath: [] });
    }

    xhandleDrop(e) {
        const { moveComponent } = this.props;
        if (moveComponent) {
            moveComponent('0', e.name);
        }
    }
}

export default Structure;
