import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router';
import Toolbox from '../components/Toolbox';
import Structure from '../components/Structure';
import Properties from '../components/Properties';

class Edit extends Component {

    componentDidMount() {
        // const { dispatch, selectedReddit } = this.props
        // dispatch(fetchPostsIfNeeded(selectedReddit))
    }

    componentWillReceiveProps(nextProps) {
        // if (nextProps.selectedReddit !== this.props.selectedReddit) {
        //   const { dispatch, selectedReddit } = nextProps
        //   dispatch(fetchPostsIfNeeded(selectedReddit))
        // }
    }

    render() {
        const {templatePath} = this.props;

        return (
            <div>
                <h2>{templatePath}</h2>
                <h3>{process.env.serviceRoot}</h3>
                <Link to="/">Home</Link>
                <Toolbox />
                <Structure />
                <Properties />
            </div>
        )
    }
}

const mapStateToProps = (state, ownProps) => ({
    templatePath: ownProps.location.query.templatePath
});

export default connect(mapStateToProps)(Edit);
