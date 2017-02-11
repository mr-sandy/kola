import { RECEIVE_AMENDMENT, fetchComponent } from '../actions';

export const amendmentMiddleware = ({ dispatch }) => next => action => {

    switch (action.type) {
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
