import { ADD_COMPONENT, RECEIVE_AMENDMENT, postAmendment, fetchComponent } from '../actions';

export const amendmentMiddleware = ({ dispatch }) => next => action => {

    switch (action.type) {
        case ADD_COMPONENT:
            dispatch(postAmendment('/test', {
                amendmentType: 'addComponent',
                componentType: action.payload.componentType,
                targetPath: '/3/0/0'
            }));
            break;

            //case ADD_COMPONENT:
            //    dispatch(postAmendment('/test', {
            //        amendmentType: 'moveComponent',
            //        sourcePath: '0',
            //        targetPath: '1'
            //    }));
            //    break;

        case RECEIVE_AMENDMENT:
        {
            const affected = action.payload.links.filter(l => l.rel === 'affected').map(l => l.href);

            affected.forEach(componentPath => {
                dispatch(fetchComponent('/test',componentPath));
            });
            break;
        }
        default:
            break;
    }

    return next(action);
}
