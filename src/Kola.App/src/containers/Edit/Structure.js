import { connect } from 'react-redux';
import { selectComponent, highlightComponent, dehighlightComponent, addComponent } from '../../actions';
import Structure from '../../components/Edit/Structure';

const mapStateToProps = state => ({
    components: state.template.components,
    selectedComponent: state.selection.selectedComponent,
    highlightedComponent : state.selection.highlightedComponent
});

const mapDispatchToProps = {
    selectComponent,
    highlightComponent,
    dehighlightComponent,
    addComponent
};

export default connect(mapStateToProps, mapDispatchToProps)(Structure);