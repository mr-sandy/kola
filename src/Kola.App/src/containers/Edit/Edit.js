import { connect } from 'react-redux';
import { fetchTemplate, togglePinToolbars } from '../../actions';
import Edit from '../../components/Edit';
import { initialiseOnMount } from '../helpers/higherOrderComponents';
import { DragDropContext } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';

const mapStateToProps = state => ({
    toolbarsPinned: state.application.toolbarsPinned
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    initialise: () => dispatch(fetchTemplate(ownProps.location.query.templatePath)),
    togglePinToolbars: () => dispatch(togglePinToolbars())
});

export default DragDropContext(HTML5Backend)(connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Edit)));
