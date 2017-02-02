
export const groupBy = (items, keyFunc) => items.reduce((groups, item) => {

        const matchedGroup = groups.find(g => g.key === keyFunc(item));

        if (matchedGroup) {
            matchedGroup.items.push(item)
        } else {
            groups.push({
                key: keyFunc(item),
                items: [item]
            });
        }

        return groups;
    },
    []
);

export const orderBy = (items, orderPropertyFunc) => items.sort((a, b) => {
    var propertyA = orderPropertyFunc(a);
    var propertyB = orderPropertyFunc(b);

    if (propertyA < propertyB) {
        return -1;
    }
    if (propertyA > propertyB) {
        return 1;
    }

    return 0;
});