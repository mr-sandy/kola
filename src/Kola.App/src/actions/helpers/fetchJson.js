import es6promise from 'es6-promise';
import fetch from 'isomorphic-fetch';
es6promise.polyfill();

function checkStatus(response) {
    if(response.ok) {
        return response;
    } else {
        const error = new Error(response.statusText);
        error.response = response;
        throw error;
    }
}

export default async function fetchJSON(url, headers = {}) {

    let response = await fetch(url, {
        method: 'get',
        headers: {
            ...headers,
            'Accept': 'application/json'
},
credentials: 'same-origin'
});

response = checkStatus(response);
return await response.json();
}