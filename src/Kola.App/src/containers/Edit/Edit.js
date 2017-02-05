import { connect } from 'react-redux';
import { fetchTemplate, togglePinToolbars } from '../../actions';
import Edit from '../../components/Edit';
import { initialiseOnMount } from '../helpers/higherOrderComponents';

const mapStateToProps = state => ({
    toolbarsPinned: state.application.toolbarsPinned
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    initialise: () => dispatch(fetchTemplate(ownProps.location.query.templatePath)),
    togglePinToolbars: () => dispatch(togglePinToolbars())
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Edit));