import { connect } from 'react-redux';
import { togglePinToolbars } from '../../actions';
import SideBar from '../../components/Edit/SideBar';

const mapStateToProps = state => ({
    toolbarsPinned: state.application.toolbarsPinned
});

const mapDispatchToProps = { togglePinToolbars };

export default connect(mapStateToProps, mapDispatchToProps)(SideBar);