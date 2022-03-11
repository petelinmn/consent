import React, { Component } from 'react';
import { ConsentBoard } from '../../../common/ConsentBoard';

const Shop = () => {
  const displayName = Shop.name;

  return (
    <div>
      <ConsentBoard appId={'shop'} />
    </div>
  )
}

export { Shop };

/*export class Kopa extends Component {
  static displayName = Kopa.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.!!!!</p>

        <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

        <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
      </div>
    );
  }
}
*/