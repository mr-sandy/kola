import { connect } from 'react-redux';
import { fetchComponents } from '../../actions';
import Toolbox from '../../components/Edit/Toolbox';
import { initialiseOnMount } from '../helpers/higherOrderComponents';

const mapStateToProps = state => ({
    components: state.components
});

const mapDispatchToProps = dispatch => ({
    initialise: () => dispatch(fetchComponents())
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Toolbox));