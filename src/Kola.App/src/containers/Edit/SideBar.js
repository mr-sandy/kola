import { connect } from 'react-redux';
import { togglePinToolbars, toggleToolbox, toggleStructure, toggleProperties, saveAmendments, undoAmendment } from '../../actions';
import SideBar from '../../components/Edit/SideBar';

const mapStateToProps = state => ({
    ...state.application,
    amendments: state.amendments
});

const mapDispatchToProps = {
    togglePinToolbars, 
    toggleToolbox, 
    toggleStructure, 
    toggleProperties, 
    saveAmendments, 
    undoAmendment
};

export default connect(mapStateToProps, mapDispatchToProps)(SideBar);