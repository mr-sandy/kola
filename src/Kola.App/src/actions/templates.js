import fetchJSON from './helpers/fetchJson';
import config from '../config';

export const RECEIVE_COMPONENTS = 'RECEIVE_COMPONENTS';
export const RECEIVE_TEMPLATE = 'RECEIVE_TEMPLATE';
export const SELECT_COMPONENT = 'SELECT_COMPONENT';
export const HIGHLIGHT_COMPONENT = 'HIGHLIGHT_COMPONENT';
export const DEHIGHLIGHT_COMPONENT = 'DEHIGHLIGHT_COMPONENT';

export const receiveComponents = components => ({
    type: RECEIVE_COMPONENTS,
    payload: components
});

export const receiveTemplate = template => ({
    type: RECEIVE_TEMPLATE,
    payload: template
});

export const selectComponent = componentPath => ({
    type: SELECT_COMPONENT,
    payload: componentPath
});

export const highlightComponent = componentPath => ({
    type: HIGHLIGHT_COMPONENT,
    payload: componentPath
});

export const dehighlightComponent = componentPath => ({
    type: DEHIGHLIGHT_COMPONENT,
    payload: componentPath
});

export const fetchComponents = () => async dispatch => {
    try {
        const data = await fetchJSON(`${config.appRoot}/component-types`);
        dispatch(receiveComponents(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}

export const fetchTemplate = templatePath => async dispatch => {
    try {
        const data = await fetchJSON(`${config.appRoot}/templates?templatePath=${templatePath}`);
        dispatch(receiveTemplate(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}
