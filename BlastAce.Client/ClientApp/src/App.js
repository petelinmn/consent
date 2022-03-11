import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Kopa } from './components/Apps/Kopa/index';
import { Shop } from './components/Apps/Shop/index';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/kopa' component={Kopa} />
        <Route path='/shop' component={Shop} />
      </Layout>
    );
  }
}
