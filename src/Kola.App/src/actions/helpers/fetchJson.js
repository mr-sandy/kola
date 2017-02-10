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

async function fetchJSON(url, headers = {}) {

    let response = await fetch(url, {
        method: 'GET',
        headers: {
            ...headers,
            'Accept': 'application/json'
},
credentials: 'same-origin'
});

response = checkStatus(response);
return await response.json();
};

async function postJSON(url, body, headers) {

    let response = await fetch(url, {
        method: 'POST',
        headers: {
            ...headers,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
},
body: body && typeof body !== 'string' ? JSON.stringify(body) : '',
credentials: 'same-origin'
});

response = checkStatus(response);
return await response.json();
}

export { fetchJSON, postJSON }