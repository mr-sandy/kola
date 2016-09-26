import fetch from 'isomorphic-fetch';

function checkStatus(response) {
    if (response.ok) {
        return response;
    } else {
        const error = new Error(response.statusText);
        error.response = response;
        throw error;
    }
}

function parseJSON(response) {
    return response.json();
}

export default function fetchJSON(url, options) {
    if (options) {
        options.headers = Object.assign({
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
            options.headers);
        if (options.body && typeof options.body !== 'string') {
            options.body = JSON.stringify(options.body);
        }
    } else {
        options = {};
    }

    return fetch(url, options)
        .then(checkStatus)
        .then(parseJSON);
}