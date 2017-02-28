import { RECEIVE_COMPONENT, RECEIVE_TEMPLATE, RECEIVE_HTML, fetchHtml } from '../actions';
import previewBroker from '../previewBroker';

export const previewMiddleware = ({ dispatch, getState }) => next => action => {

    switch (action.type) {
        case RECEIVE_COMPONENT:
            {
                const componentPath = action.payload.path;
                const previewUrl = action.payload.links.find(l => l.rel === 'preview').href;

                dispatch(fetchHtml(componentPath, previewUrl));
                break;
            }
        case RECEIVE_TEMPLATE:
            {
                previewBroker.refresh();
                break;
            }
        case RECEIVE_HTML:
            {
                const componentPath = action.payload.componentPath;
                const html = action.payload.html;

                previewBroker.update(componentPath, html);
                break;
            }
        default:
            break;
    }

    return next(action);
}
