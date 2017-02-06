import React  from 'react';
import StructureComponent from './StructureComponent';

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
            { components.map((c, i) => <StructureComponent key={i} component={c} {...props} />) }
        </div>
    );
}

export default Area;
