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

const getComponentColour = componentType => {
    switch (componentType) {
    case 'atom':
        return 'rgba(178,32,40,0.4)';

        case 'container':
            return 'rgba(32,113,178,0.4)';

        case 'widget':
            return 'rgba(178,97,32,0.4)';
        
        default:
            return 'rgba(255,255,255,0.4)';
    }
}

class KolaComponent extends Component {
    render() {
        const { component, selectComponent  = () => {}, highlightComponent  = () => {}, dehighlightComponent  = () => {}, selectedComponent, highlightedComponent } = this.props;
        
        const children = component.areas || component.components || [];
        
        let outerStyle = component.path === highlightedComponent ? { ...styles.outer, backgroundColor: 'rgba(255,255,255,0.2)' } : styles.outer;
        outerStyle = component.path === selectedComponent ? { ...outerStyle, borderColor: '#fff', backgroundColor: getComponentColour(component.type) } : outerStyle;

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
                return (
                    <Accordian outerStyle={outerStyle} 
                                   captionStyle={styles.caption} 
                                   innerStyle={styles.inner} caption={`${component.type}: ${component.name}`} 
                                   className='transition-all'
                                   onMouseOver={e => this.handleMouseOver(e)}
                                   onMouseLeave={e => this.handleMouseLeave(e)}
                                   onClick={e => this.handleClick(e)}>
{component.components.map((c, i) => <KolaComponent key={i} component={c} selectComponent={selectComponent} highlightComponent={highlightComponent} dehighlightComponent={dehighlightComponent} selectedComponent={selectedComponent} highlightedComponent={highlightedComponent} />)}
                    </Accordian>
                );

            case 'widget':
                return (
                    <Accordian outerStyle={outerStyle} 
                                   captionStyle={styles.caption} 
                                   innerStyle={styles.inner} caption={`${component.type}: ${component.name}`} 
                                   className='transition-all'
                                   onMouseOver={e => this.handleMouseOver(e)}
                                   onMouseLeave={e => this.handleMouseLeave(e)}
                                   onClick={e => this.handleClick(e)}>
{children.map((c, i) => <KolaComponent key={i} component={c} selectComponent={selectComponent} highlightComponent={highlightComponent} dehighlightComponent={dehighlightComponent}  selectedComponent={selectedComponent} highlightedComponent={highlightedComponent} />)}
                    </Accordian>
                );

            default:
                return false;
        }
    }

    handleClick(e) {
        e.stopPropagation();

        const { component, selectComponent  = () => {}} = this.props;
        selectComponent(component.path);
    }

    handleMouseOver(e) {
        e.stopPropagation();

        const { component, highlightComponent = () => {} } = this.props;
        highlightComponent(component.path)
    }

    handleMouseLeave(e) {
        e.stopPropagation();

        const { component, dehighlightComponent = () => {} } = this.props;
        dehighlightComponent(component.path)
    }
}

export default KolaComponent;
