import { fetchJSON, postJSON, putJSON , deleteJSON } from './helpers/fetchJson';
import { selectComponent, hideComponent } from './templates';
import config from '../config';

export const RECEIVE_AMENDMENT = 'RECEIVE_AMENDMENT';
export const RECEIVE_AMENDMENTS = 'RECEIVE_AMENDMENTS';

export const receiveAmendment = amendment => ({
    type: RECEIVE_AMENDMENT,
    payload: amendment
});

export const receiveAmendments = amendments => ({
    type: RECEIVE_AMENDMENTS,
    payload: amendments
});

const postAmendment = amendment => async (dispatch, getState) => {
    const amendmentsUrl = (getState().template.links.find(l => l.rel === 'amendments').href);
    
    try {
        const data = await postJSON(`${config.appRoot}${amendmentsUrl}`, amendment);
        dispatch(receiveAmendment(data));
    } catch (error) {
        console.log(`post failed ${error}`);
    }
}

export const addComponent = (targetPath, componentType) => async dispatch => {
    dispatch(selectComponent(''));
    dispatch(postAmendment(
    {
        amendmentType: 'addComponent',
        componentType,
        targetPath
    }));
};

export const moveComponent = (sourcePath, targetPath) => async dispatch => {
    dispatch(hideComponent(sourcePath));
    dispatch(selectComponent(''));
    dispatch(postAmendment(
    {
        amendmentType: 'moveComponent',
        sourcePath,
        targetPath
    }));
};

export const removeComponent = componentPath => async dispatch => {
    dispatch(selectComponent(''));
    dispatch(postAmendment(
    {
        amendmentType: 'removeComponent',
        componentPath
    }));
};

export const duplicateComponent = componentPath => async dispatch => {
    dispatch(selectComponent(''));
    dispatch(postAmendment(
    {
        amendmentType: 'duplicateComponent',
        componentPath
    }));
};


export const setProperty = (componentPath, propertyName, value) => async dispatch => {
    dispatch(postAmendment(
    {
        amendmentType: 'setPropertyFixed',
        componentPath, 
        propertyName, 
        value: value.value
    }));
};

export const fetchAmendments = () => async (dispatch, getState) => {
    try {
        const amendmentsUrl = (getState().template.links.find(l => l.rel === 'amendments').href);
        const data = await fetchJSON(`${config.appRoot}${amendmentsUrl}`);
        dispatch(receiveAmendments(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}

export const saveAmendments = () => async (dispatch, getState) => {
    try {
        const amendmentsUrl = (getState().template.links.find(l => l.rel === 'amendments').href);
        const data = await putJSON(`${config.appRoot}${amendmentsUrl}`);
        dispatch(receiveAmendments(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}

export const undoAmendment = () => async (dispatch, getState) => {
    try {
        const amendmentsUrl = (getState().template.links.find(l => l.rel === 'amendments').href);
        const data = await deleteJSON(`${config.appRoot}${amendmentsUrl}`);
        dispatch(receiveAmendments(data));
    } catch (error) {
        console.log(`request failed ${error}`);
    }
}
