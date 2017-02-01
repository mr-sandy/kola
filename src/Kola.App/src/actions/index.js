import fetchJSON from './helpers/fetchJson';
import config from '../config';

export const RECEIVE_COMPONENTS = 'RECEIVE_COMPONENTS';

export const receiveComponents = components => ({
    type: RECEIVE_COMPONENTS,
    payload: components
});

export const fetchComponents = () => async dispatch => {
    try {
        const data = await fetchJSON(`${config.appRoot}/component-types`);
        dispatch(receiveComponents(data));
    } catch (error) {
        console.log(`order request failed ${error}`);
        //dispatch(receiveOrderError());
    }
}
