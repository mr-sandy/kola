import { RECEIVE_AMENDMENT, fetchComponent, fetchTemplate } from '../actions';

const getTemplatePath = template => template.links ? template.links.find(l => l.rel === 'path').href : '';

export const amendmentMiddleware = ({ dispatch, getState }) => next => action => {

    switch (action.type) {
        case RECEIVE_AMENDMENT:
        {
            const affected = action.payload.links.filter(l => l.rel === 'affected').map(l => l.href);
            const templatePath = getTemplatePath(getState().template);

            affected.forEach(componentPath => {

                if (componentPath) {
                    dispatch(fetchComponent(templatePath, componentPath));
                } else {
                    dispatch(fetchTemplate(templatePath));
                }
            });
            break;
        }
        default:
            break;
    }

    return next(action);
}
