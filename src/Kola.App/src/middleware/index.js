import { RECEIVE_AMENDMENT, fetchComponent, fetchTemplate, selectComponent, unhideComponent } from '../actions';

const getTemplatePath = template => template.links ? template.links.find(l => l.rel === 'path').href : '';

export const amendmentMiddleware = ({ dispatch, getState }) => next => action => {

    switch (action.type) {
        case RECEIVE_AMENDMENT:
        {
            const affected = action.payload.links.filter(l => l.rel === 'affected').map(l => l.href);
            const subject = action.payload.links.find(l => l.rel === 'subject').href;
            const templatePath = getTemplatePath(getState().template);

            affected.forEach(componentPath => {
                if (componentPath && componentPath !== '/') {
                    dispatch(fetchComponent(templatePath, componentPath));
                } else {
                    dispatch(fetchTemplate(templatePath));
                }
            });

            dispatch(unhideComponent());
            dispatch(selectComponent(subject, false));

            break;
        }
        default:
            break;
    }

    return next(action);
}
