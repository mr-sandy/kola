import es6promise from 'es6-promise';
import fetch from 'isomorphic-fetch';
es6promise.polyfill();

const checkStatus = (response) => {
    if(response.ok) {
        return response;
    } else {
        const error = new Error(response.statusText);
        error.response = response;
        throw error;
    }
}

export const fetchJSON = async (url, headers = {}) => {

    let response = await fetch(url,
    {
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

export const postJSON = async (url, body, headers) => {

    let response = await fetch(url,
    {
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
};

export const putJSON = async (url, body, headers) => {

    let response = await fetch(url,
    {
        method: 'PUT',
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
};

export const deleteJSON = async (url, headers) => {

    let response = await fetch(url,
    {
        method: 'DELETE',
        headers: {
            ...headers,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        credentials: 'same-origin'
    });

    response = checkStatus(response);
    return await response.json();
};

export const fetchHTML = async (url, headers = {}) => {

    let response = await fetch(url,
    {
        method: 'GET',
        headers: {
            ...headers,
            'Accept': 'text/html'
        },
        credentials: 'same-origin'
    });

        response = checkStatus(response);
    const html = await response.text();
    return html;
};


