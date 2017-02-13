import { postJSON } from './helpers/fetchJson';
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

export const addComponent = (templatePath, componentPath, componentType) => async dispatch => {
    postAmendment(dispatch, templatePath,
    {
        amendmentType: 'addComponent',
        componentType,
        targetPath: '/' + componentPath.join('/')
    });
};

export const moveComponent = (templatePath, sourcePath, targetPath) => async dispatch => {
    postAmendment(dispatch, templatePath,
    {
        amendmentType: 'moveComponent',
        sourcePath:  '/' + sourcePath.join('/'),
        targetPath:  '/' + targetPath.join('/')
    });
};

