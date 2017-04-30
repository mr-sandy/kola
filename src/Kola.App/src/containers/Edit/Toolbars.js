import { connect } from 'react-redux';
import Toolbars from '../../components/Edit/Toolbars';

const mapStateToProps = ({ application }) => ({
    toolbarsPinned: application.toolbarsPinned
});

const mapDispatchToProps = {
};

export default connect(mapStateToProps, mapDispatchToProps)(Toolbars);