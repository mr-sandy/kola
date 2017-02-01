import React from 'react';
import { IndexLink } from 'react-router';

const Templates = props => {

    return (
        <div>
            <h1>Kola - Templates</h1>
            <IndexLink to="/_kola">Home</IndexLink> <IndexLink to="/_kola/templates/edit">Edit</IndexLink>
        </div>
    );
}

export default Templates;