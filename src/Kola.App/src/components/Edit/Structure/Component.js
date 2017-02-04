import React, { Component } from 'react';
import Accordian from '../Accordian';

const styles = {
    outer: {
        color: '#eee',
        borderWidth: '1px',
        borderColor: '#ccc',
        borderStyle: 'solid',
        marginBottom: '8px'
    },
    caption: {
        display: 'block',
        padding: '8px'
    },
    inner: {
        padding: '8px 8px 0 8px',
        borderTopWidth: '1px',
        borderTopColor: '#ccc',
        borderTopStyle: 'solid'
    }
};

class KolaComponent extends Component {
    render() {
        const { component, selectComponent, highlightComponent, selectedComponent, highlightedComponent } = this.props;
        
        const children = component.areas || component.components || [];
        
        let outerStyle = component.path === highlightedComponent ? { ...styles.outer, backgroundColor: 'rgba(255,255,255,0.2)' } : styles.outer;
        outerStyle = component.path === selectedComponent ? { ...outerStyle, borderColor: '#fff', backgroundColor: 'rgba(255,255,255,0.4)' } : outerStyle;

        switch (component.type) {
            case 'atom':
                return (
                    <div style={outerStyle} 
                         className='transition-all'
                         onMouseOver={e => this.handleMouseOver(e)}
                         onMouseLeave={e => this.handleMouseLeave(e)}
                         onClick={e => this.handleClick(e)}>
                        <span style={styles.caption}>{component.type}: {component.name}</span>
                    </div>
                );

            case 'container':
            case 'widget':
                return (<Accordian outerStyle={outerStyle} 
                                   captionStyle={styles.caption} 
                                   innerStyle={styles.inner} caption={`${component.type}: ${component.name}`} 
                                   className='transition-all'
                                   onMouseOver={e => this.handleMouseOver(e)}
                                   onMouseLeave={e => this.handleMouseLeave(e)}
                                   onClick={e => this.handleClick(e)}>
                    {children.map((c, i) => <KolaComponent key={i} component={c} selectComponent={selectComponent} highlightComponent={highlightComponent} selectedComponent={selectedComponent} highlightedComponent={highlightedComponent} />)}
                </Accordian>
                );

            default:
                return false;
        }
    }

    handleClick(e) {
        e.stopPropagation();

        const { component, selectComponent } = this.props;
        if (selectComponent) {
            selectComponent(component.path);
        }
    }

    handleMouseOver(e) {
        e.stopPropagation();

        const { component, highlightComponent, highlightedComponent } = this.props;

        if (highlightComponent && highlightedComponent !== component.path) {
            highlightComponent(component.path)
        }
    }

    handleMouseLeave(e) {
        e.stopPropagation();

        const { component, highlightComponent, highlightedComponent } = this.props;

        if (highlightComponent && highlightedComponent === component.path) {
            highlightComponent(component.path)
        }
    }
}

export default KolaComponent;
