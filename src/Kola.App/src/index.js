import React from 'react';
import { render } from 'react-dom';
import Root from './containers/Root';
import createStoreFunction from './configureStore';
import './sass/index.scss';

const store = createStoreFunction({});
const rootEl = document.getElementById('root');

render(
    <Root store={store} />,
    rootEl
);

if (module.hot) {
    module.hot.accept('./containers/Root', () => {
        const NextApp = require('./containers/Root').default;
        render(
            <NextApp store={store} />,
            rootEl
        );
    });
}

//function dorender(Component) {
//    render(
//        (
//            <Component store={store}/>
//        ),
//        document.getElementById('root')
//    );
//}

//    dorender(Root);

//if (module.hot) {
//    module.hot.accept('./containers/Root', () => {
//        const NextApp = dorender('./Root').default;
//        render(NextApp);
//    });
//}