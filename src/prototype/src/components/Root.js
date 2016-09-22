import React from 'react'
import { Provider } from 'react-redux';
import { Router, Route, Redirect, IndexRoute, browserHistory } from 'react-router';
import App from './App';
import Home from './Home';
import Edit from '../containers/Edit';

const Root = ({ store }) => (
  <Provider store={store}>
    <Router history={browserHistory}>
      <Route name="Home" path="/" component={App}>
        <IndexRoute name="Home" component={Home} />
        <Route name="Edit" path="/edit" component={Edit} />
      </Route>
    </Router>
  </Provider>);

export default Root;

                // <IndexRoute name="Select Report" component={SelectReport} />
                // <Route name="Customer Sales Report" path="customer-sales-report">
                //     <IndexRoute name="reports-home" component={ConfigureCustomerSalesReport} />
                //     <Route name="Details" path=":customerParam" component={ShowCustomerSalesReport} />
                // </Route>
