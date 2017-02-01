import React from 'react';
import { Provider } from 'react-redux';
import { Router, Route, Redirect, IndexRoute, browserHistory } from 'react-router';
import EditContainer from './EditContainer';
import App from '../components/App';
import Home from '../components/Home';
import Templates from '../components/Templates';

const Root = ({ store }) => (
    <Provider store={store}>
        <Router history={browserHistory}>
            <Redirect from="/" to="_kola" />
            <Route name="home" path="_kola" component={App}>
                <IndexRoute component={Home} />
                <Route name="templates" path="templates">
                    <IndexRoute component={Templates} />
                    <Route name="edit" path="edit" component={EditContainer} />
                </Route>
            </Route>
        </Router>
    </Provider>);

export default Root;