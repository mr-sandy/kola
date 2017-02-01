import React from 'react';
import { IndexLink } from 'react-router';

const Home = props => {

    return (
    <div>
        <h1>Kola</h1>
        <IndexLink to="/_kola/templates">Templates</IndexLink>
    </div>
    );
}

export default Home;