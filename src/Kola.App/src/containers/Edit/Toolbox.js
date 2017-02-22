import { connect } from 'react-redux';
import { fetchComponentTypes, showPlaceholder, hidePlaceholder } from '../../actions';
import Toolbox from '../../components/Edit/Toolbox';
import { initialiseOnMount } from '../helpers/higherOrderComponents';

const mapStateToProps = state => ({
    componentTypes: state.componentTypes,
    showToolbox: state.application.showToolbox
});

const mapDispatchToProps = dispatch => ({
    initialise: () => dispatch(fetchComponentTypes()),
    showPlaceholder: path => dispatch(showPlaceholder(path)),
    hidePlaceholder: path => dispatch(hidePlaceholder(path))
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Toolbox));