import React, { Component } from 'react';

export const initialiseOnMount = ComposedComponent => class extends Component {

    componentDidMount() {
        const { initialise } = this.props;
        if (initialise) {
            initialise(this.props);
        }
    }

    render() {
        return <ComposedComponent {...this.props} />;
    }
}