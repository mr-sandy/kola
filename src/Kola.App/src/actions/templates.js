import { fetchJSON, postJSON } from './helpers/fetchJson';
import config from '../config';

export const RECEIVE_COMPONENTS = 'RECEIVE_COMPONENTS';
export const RECEIVE_TEMPLATE = 'RECEIVE_TEMPLATE';
export const SELECT_COMPONENT = 'SELECT_COMPONENT';
export const HIGHLIGHT_COMPONENT = 'HIGHLIGHT_COMPONENT';
export const DEHIGHLIGHT_COMPONENT = 'DEHIGHLIGHT_COMPONENT';
export const ADD_COMPONENT = 'ADD_COMPONENT';
export const RECEIVE_AMENDMENT = 'RECEIVE_AMENDMENT';

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

export const addComponent = (componentPath, componentType) => ({
    type: ADD_COMPONENT,
    payload: { componentPath, componentType }
});

export const receiveAmendment = amendment => ({
    type: RECEIVE_AMENDMENT,
    payload: amendment
});

// note: toolox component
export const fetchComponents = () => async dispatch => {
    try {
        const data = await fetchJSON(`${config.appRoot}/component-types`);
        dispatch(receiveComponents(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}

// note: template component
export const fetchComponent = (templatePath = '/test', componentPath) => async dispatch => {
    try {
        const data = await fetchJSON(`${config.appRoot}/templates/components?templatePath=${templatePath}&componentPath=${componentPath}`);
        console.log(data);
        //dispatch(receiveComponents(data));
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

export const postAmendment = (templatePath, amendment) => async dispatch => {
    try {
        const data = await postJSON(`${config.appRoot}/templates/amendments?templatePath=${templatePath}`, amendment);
        dispatch(receiveAmendment(data));
    } catch (error) {
        console.log(`post failed ${error}`);
    }
}