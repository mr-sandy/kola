import { fetchJSON, fetchHTML } from './helpers/fetchJson';
import { fetchAmendments } from './amendments';
import config from '../config';

export const RECEIVE_COMPONENT_TYPES = 'RECEIVE_COMPONENT_TYPES';
export const RECEIVE_TEMPLATE = 'RECEIVE_TEMPLATE';
export const SELECT_COMPONENT = 'SELECT_COMPONENT';
export const HIGHLIGHT_COMPONENT = 'HIGHLIGHT_COMPONENT';
export const UNHIGHLIGHT_COMPONENT = 'UNHIGHLIGHT_COMPONENT';
export const RECEIVE_COMPONENT = 'RECEIVE_COMPONENT';
export const SHOW_PLACEHOLDER = 'SHOW_PLACEHOLDER';
export const HIDE_PLACEHOLDER = 'HIDE_PLACEHOLDER';
export const HIDE_COMPONENT = 'HIDE_COMPONENT';
export const UNHIDE_COMPONENT = 'HIDE_COMPONENT';
export const RECEIVE_HTML = 'RECEIVE_HTML';
export const SELECT_PROPERTY = 'SELECT_PROPERTY';

export const receiveComponentTypes = components => ({
    type: RECEIVE_COMPONENT_TYPES,
    payload: components
});

export const receiveTemplate = template => ({
    type: RECEIVE_TEMPLATE,
    payload: template
});

export const selectComponent = (componentPath, toggle = true) => ({
    type: SELECT_COMPONENT,
    payload: { componentPath, toggle }
});

export const highlightComponent = componentPath => ({
    type: HIGHLIGHT_COMPONENT,
    payload: componentPath
});

export const unhighlightComponent = componentPath => ({
    type: UNHIGHLIGHT_COMPONENT,
    payload: componentPath
});

export const receiveComponent = component => ({
    type: RECEIVE_COMPONENT,
    payload: component
});

export const showPlaceholder = placeholderPath => ({
    type: SHOW_PLACEHOLDER,
    payload: placeholderPath
});

export const hidePlaceholder = placeholderPath => ({
    type: HIDE_PLACEHOLDER,
    payload: placeholderPath
});

export const hideComponent = componentPath => ({
    type: HIDE_COMPONENT,
    payload: componentPath
});

export const unhideComponent = () => ({
    type: UNHIDE_COMPONENT,
    payload: ''
});

export const receiveHtml = (componentPath, html) => ({
    type: RECEIVE_HTML,
    payload: { componentPath, html }
});

export const selectProperty = propertyName => ({
    type: SELECT_PROPERTY,
    payload: propertyName
});

export const fetchComponentTypes = () => async dispatch => {
    try {
        const data = await fetchJSON(`${config.appRoot}/_kola/component-types`);
        dispatch(receiveComponentTypes(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}

export const fetchComponent = (templatePath, componentPath) => async dispatch => {
    try {
        const data = await fetchJSON(`${config.appRoot}/_kola/templates/components?templatePath=${templatePath}&componentPath=${componentPath}`);
        dispatch(receiveComponent(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}

export const fetchTemplate = templatePath => async dispatch => {
    try {
        const template = await fetchJSON(`${config.appRoot}/_kola/templates?templatePath=${templatePath}`);
        dispatch(receiveTemplate(template));
        dispatch(fetchAmendments());
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}

export const fetchHtml = (componentPath, previewUrl) => async dispatch => {
    try {
        const html = await fetchHTML(`${config.appRoot}/${previewUrl}`);
        dispatch(receiveHtml(componentPath, html));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}
