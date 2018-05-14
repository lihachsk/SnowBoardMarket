import * as React from 'react'
import * as ReactDOM from 'react-dom'
import { AppContainer } from 'react-hot-loader'
import { createStore, applyMiddleware } from 'redux';
import { Route } from 'react-router';
import createHistory from 'history/createBrowserHistory';
import { routerMiddleware, ConnectedRouter, routerReducer } from 'react-router-redux';
import { Provider } from 'react-redux';
import { HashRouter } from 'react-router-dom';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import { reducers, ApplicationState } from 'reducers';
import App from 'containers/App'

const history = createHistory();
const middleware = routerMiddleware(history);

const store = createStore(reducers, composeWithDevTools(
    applyMiddleware(
        thunk,
        middleware
    )
));

const render = App => {
    ReactDOM.render(
        <Provider store={store}>
            <HashRouter>
                <AppContainer>
                    <App />
                </AppContainer>
            </HashRouter>
        </Provider>,
        document.getElementById('root'),
    )
}

render(App)

// Webpack Hot Module Replacement API
if (module.hot) {
    module.hot.accept('containers/App', () => {
        // if you are using harmony modules ({modules:false})
        render(App)
        // in all other cases - re-require App manually
        render(require('containers/App'))
    })
}