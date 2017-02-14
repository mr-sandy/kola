
export const commonStyles = {
    outer: {
        color: '#eee',
        borderWidth: '1px',
        borderColor: '#ccc',
        borderStyle: 'solid',
        marginBottom: '0'
    },
    inner: {
        padding: '8px 8px 8px 8px',
        borderTopWidth: '1px',
        borderTopColor: '#ccc',
        borderTopStyle: 'solid'
    },
    caption: {
        display: 'block',
        padding: '8px'
    }
};

const selectedColours = {
    atom: 'rgba(178,32,40,0.4)',
    container: 'rgba(32,113,178,0.4)',
    widget: 'rgba(178,97,32,0.4)'
}

export const buildOuterStyle = (componentType, isSelected, isHighlighted) => {

    if (isSelected) {
        return { ...commonStyles.outer, backgroundColor: selectedColours[componentType] };
    }

    if (isHighlighted) {
        return { ...commonStyles.outer, backgroundColor: 'rgba(255,255,255,0.2)' };
    }

    return commonStyles.outer;
};

