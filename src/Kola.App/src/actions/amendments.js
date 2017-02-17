import { postJSON } from './helpers/fetchJson';
import { selectComponent, hideComponent } from './templates';
import config from '../config';

export const RECEIVE_AMENDMENT = 'RECEIVE_AMENDMENT';

export const receiveAmendment = amendment => ({
    type: RECEIVE_AMENDMENT,
    payload: amendment
});

const postAmendment = async (dispatch, templatePath, amendment) => {
    try {
        dispatch(selectComponent(''));
        const data = await postJSON(`${config.appRoot}/templates/amendments?templatePath=${templatePath}`, amendment);
        dispatch(receiveAmendment(data));
    } catch (error) {
        console.log(`post failed ${error}`);
    }
}

export const addComponent = (templatePath, targetPath, componentType) => async dispatch => {
    postAmendment(dispatch, templatePath,
    {
        amendmentType: 'addComponent',
        componentType,
        targetPath
    });
};

export const moveComponent = (templatePath, sourcePath, targetPath) => async dispatch => {
    dispatch(hideComponent(sourcePath));
    postAmendment(dispatch, templatePath,
    {
        amendmentType: 'moveComponent',
        sourcePath,
        targetPath
    });
};

