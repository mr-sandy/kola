import React, { Component } from 'react';
import ComponentList from './ComponentList';
import Toolbar from '../Toolbar';
import ToolbarContent from '../ToolbarContent';
import ToolbarButtonTray from '../ToolbarButtonTray';
import Button from '../Button';

const arraysMatch = (arr1, arr2) => {
    if (!arr1 || !arr2) {
        return false
    }

    if (arr1.length !== arr2.length) {
        return false;
    }

    for (let i = 0; i < arr1.length; i++) {
        if (arr1[i] !== arr2[i]) {
            return false;
        }
    }

    return true;
}

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
                    <ComponentList components={components} componentPath="/" placeholderPath={this.state.placeholderPath} setPlaceholderPath={p => this.setPlaceholderPath(p) }{...otherProps} style={{ minHeight: '100%' }} onDrop={(e, f) => this.handleDrop(e, f)} />
                </ToolbarContent>
                <ToolbarButtonTray>
                    <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon="fa-cog" active={false} />
                </ToolbarButtonTray>
            </Toolbar>
        );
    }

    handleDrop(e, componentPath) {
        const { addComponent } = this.props;
        if (addComponent) {
            addComponent(componentPath, e.name);
        }
    }

    xhandleDrop(e) {
        const { moveComponent } = this.props;
        if (moveComponent) {
            moveComponent('0', e.name);
        }
    }
}

export default Structure;
