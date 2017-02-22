import { RECEIVE_COMPONENT } from '../actions';
import previewBroker from '../previewBroker';

//const getTemplatePath = template => template.links ? template.links.find(l => l.rel === 'path').href : '';

export const previewMiddleware = ({ dispatch, getState }) => next => action => {

    switch (action.type) {
        case RECEIVE_COMPONENT:
        {
            var previewUrl = `http://localhost:61134/test?componentPath=${action.payload.path}&preview=y`;
            previewBroker.publish(previewUrl);
                break;
            }
        default:
            break;
    }

    return next(action);
}
