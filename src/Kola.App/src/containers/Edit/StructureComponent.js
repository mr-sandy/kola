import { connect } from 'react-redux';
import { selectComponent, highlightComponent } from '../../actions';
import Component from '../../components/Edit/Structure/Component';

const mapStateToProps = state => ({
    selectedComponent: state.selection.selectedComponent,
    highlightedComponent : state.selection.highlightedComponent
});

const mapDispatchToProps = {
    selectComponent,
    highlightComponent
};

export default connect(mapStateToProps, mapDispatchToProps)(Component);