let refreshHandler = () => {};
let updateHandler = () => {};

const previewBroker = {
    subscribe: (onRefresh, onUpdate) => {
        refreshHandler = onRefresh;
        updateHandler = onUpdate;
    },

    refresh: () => {
        if (refreshHandler) {
            refreshHandler();
        }
    },

    update: (componentPath, html) => {
        if (updateHandler) {
            updateHandler(componentPath, html);
        }
    }
}

export default previewBroker;