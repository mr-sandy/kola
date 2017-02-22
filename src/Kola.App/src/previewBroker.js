
let handler = () => {};

const previewBroker = {
    subscribe: h => {
        handler = h;
    },

    publish: data => {
        if (handler) {
            handler(data);
        }
    }
}

export default previewBroker;