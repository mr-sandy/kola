import { connect } from 'react-redux';
import { selectComponent, highlightComponent, unhighlightComponent, addComponent, moveComponent } from '../../actions';
import Structure from '../../components/Edit/Structure';

const mapStateToProps = state => ({
    components: state.template.components,
    selectedComponent: state.selection.selectedComponent,
    highlightedComponent : state.selection.highlightedComponent
});

const mapDispatchToProps = {
    selectComponent,
    highlightComponent,
    unhighlightComponent,
    addComponent,
    moveComponent 
};

export default connect(mapStateToProps, mapDispatchToProps)(Structure);