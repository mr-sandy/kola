import { fetchJSON, postJSON } from './helpers/fetchJson';
import config from '../config';

export const RECEIVE_AMENDMENT = 'RECEIVE_AMENDMENT';

export const receiveAmendment = amendment => ({
    type: RECEIVE_AMENDMENT,
    payload: amendment
});

const postAmendment = async (dispatch, templatePath, amendment) => {
    try {
        const data = await postJSON(`${config.appRoot}/templates/amendments?templatePath=${templatePath}`, amendment);
        dispatch(receiveAmendment(data));
    } catch (error) {
        console.log(`post failed ${error}`);
    }
}

export const addComponent = (componentPath, componentType) => async dispatch => {
    postAmendment(dispatch, '/test',
    {
        amendmentType: 'addComponent',
        componentType: componentType,
        targetPath: componentPath
    });
};

export const moveComponent = (sourcePath, targetPath) => async dispatch => {
    postAmendment(dispatch, '/test',
    {
        amendmentType: 'moveComponent',
        sourcePath: '/0/0/0',
        targetPath: '/1/0/0'
    });
};

