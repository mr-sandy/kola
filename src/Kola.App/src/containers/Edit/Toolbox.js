import { connect } from 'react-redux';
import { fetchComponentTypes, showPlaceholder, hidePlaceholder } from '../../actions';
import Toolbox from '../../components/Edit/Toolbox';
import { initialiseOnMount } from '../helpers/higherOrderComponents';

const mapStateToProps = state => ({
    componentTypes: state.componentTypes,
    showToolbox: state.application.showToolbox
});

const initialise= () => dispatch => dispatch(fetchComponentTypes());

const mapDispatchToProps = {
    initialise,
    showPlaceholder,
    hidePlaceholder
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Toolbox));