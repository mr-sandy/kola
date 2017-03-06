
export const toIntArray = componentPath => componentPath.split('/').filter(s => s).map(s => parseInt(s, 10));

export const selectComponent = (parent, path) => {
    const index = path[0];
    const children = parent.components || parent.areas;

    if (index < children.length) {
        const child = children[index];
        const remainder = path.slice(1);

        return (remainder.length > 0)
            ? selectComponent(child, remainder)
            : child;

    } else {
        console.log('Unmatched path error')
    }

    return {};
}