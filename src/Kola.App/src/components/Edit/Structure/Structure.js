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
        return (
            <Toolbar style={styles.base}>
                <ToolbarContent style={styles.content}>
                    <ComponentList components={components} {...otherProps} style={{ minHeight: '100%' }} onDrop={e => this.handleDrop(e)} />
                </ToolbarContent>
                <ToolbarButtonTray>
                    <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon="fa-cog" active={false} />
                </ToolbarButtonTray>
            </Toolbar>
        );
    }

    handleDropx(e) {
        const { addComponent } = this.props;
        if (addComponent) {
            addComponent('0', e.name);
        }
    }

    handleDrop(e) {
        const { moveComponent } = this.props;
        if (moveComponent) {
            moveComponent('0', e.name);
        }
    }
}

export default Structure;
