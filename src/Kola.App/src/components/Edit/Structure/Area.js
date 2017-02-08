import React  from 'react';
import ComponentList from './ComponentList';

const styles = {
    caption: {
        display: 'block',
        paddingBottom: '12px'
    }
}
const Area = ({ area, ...props }) => {
    const { name, components = [] } = area;
    return (
        <div>
            <span style={styles.caption}>{`area: ${name}`}</span>
            <ComponentList components={components} {...props} />
        </div>
    );
}

export default Area;
