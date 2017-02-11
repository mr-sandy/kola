import { connect } from 'react-redux';
import { fetchComponentTypes } from '../../actions';
import Toolbox from '../../components/Edit/Toolbox';
import { initialiseOnMount } from '../helpers/higherOrderComponents';

const mapStateToProps = state => ({
    componentTypes: state.componentTypes
});

const mapDispatchToProps = dispatch => ({
    initialise: () => dispatch(fetchComponentTypes())
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Toolbox));