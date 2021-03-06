﻿import * as React from 'react'
import * as ReactDOM from 'react-dom'
import { AppContainer } from 'react-hot-loader'
import { Route } from 'react-router';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import App from 'containers/App';
import Basket from 'containers/Basket';
import configureStore from './node_modules/configureStore';
import createHistory from 'history/createBrowserHistory';
import { routerMiddleware } from 'react-router-redux';
import { ApplicationState, reducers } from 'reducers';

import { createStore, applyMiddleware, combineReducers, ReducersMapObject, Store } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import appSettings from 'reducers/appSettings';
import {
    UPDATE_APPSETTINGS
} from 'actionTypes';

const history = createHistory();
const middleware = routerMiddleware(history);
const initialState = (window as any).initialReduxState as ApplicationState;

const store: Store<ApplicationState> = createStore<ApplicationState>(
    combineReducers(reducers),
    initialState,
    composeWithDevTools(
        applyMiddleware(
            thunk,
            middleware,
        )
));

const render = App => {
    ReactDOM.hydrate(
        <Provider store={store}>
            <BrowserRouter>
                <AppContainer>
                    <App />
                </AppContainer>
            </BrowserRouter>
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