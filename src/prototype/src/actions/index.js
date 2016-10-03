import { findComponentByPath } from './helpers/templateHelpers';

export const REQUEST_TEMPLATE = 'REQUEST_TEMPLATE';
export const RECEIVE_TEMPLATE = 'RECEIVE_TEMPLATE';
export const SELECT_COMPONENT = 'SELECT_COMPONENT';
export const SELECT_PROPERTY = 'SELECT_PROPERTY';

export const requestTemplate = templatePath => ({
  type: REQUEST_TEMPLATE,
  payload: { templatePath }
});

export const receiveTemplate = (templatePath, template) => ({
  type: RECEIVE_TEMPLATE,
  payload: { templatePath, template }
});

export const selectComponent = component => ({
  type: SELECT_COMPONENT,
  payload: { component }
});

export const selectProperty = property => ({
  type: SELECT_PROPERTY,
  payload: { property }
});

export const selectComponentByPath = componentPath => (dispatch, getState) => {
  const template = getState().template.template;
  const component = findComponentByPath(template, componentPath);
  return dispatch(selectComponent(component))
}

const fetchPosts = templatePath => dispatch => {
  dispatch(requestTemplate(templatePath))
  return fetch(`${process.env.serviceRoot}/_kola/templates?templatePath=${templatePath}`)
    .then(response => response.json())
    .then(template => dispatch(receiveTemplate(templatePath, template)))
}

const shouldFetchTemplate = (state, templatePath) => {
  return true;
}

export const fetchTemplateIfNeeded = templatePath => (dispatch, getState) => {
  if (shouldFetchTemplate(getState(), templatePath)) {
    return dispatch(fetchPosts(templatePath))
  }
}

