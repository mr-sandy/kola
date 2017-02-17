import { connect } from 'react-redux';
import { togglePinToolbars, saveAmendments, undoAmendment } from '../../actions';
import SideBar from '../../components/Edit/SideBar';

const mapStateToProps = state => ({
    toolbarsPinned: state.application.toolbarsPinned,
    amendments: state.amendments
});

const mapDispatchToProps = { togglePinToolbars, saveAmendments, undoAmendment };

export default connect(mapStateToProps, mapDispatchToProps)(SideBar);