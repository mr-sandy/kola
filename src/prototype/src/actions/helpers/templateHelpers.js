
export const findComponentByPath = (template, componentPath) =>
    componentPath.split('/')
        .filter(s => s)
        .map(s => parseInt(s))
        .reduce((val, i) => {
            const children = val ? val.areas || val.components || [] : [];
            return (children.length > i) ? children[i] : void 0;
        }, template);
