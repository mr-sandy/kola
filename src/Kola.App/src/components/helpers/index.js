
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
