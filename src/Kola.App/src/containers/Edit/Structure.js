import { connect } from 'react-redux';
import { selectComponent,
    highlightComponent,
    unhighlightComponent,
    addComponent,
    moveComponent,
    removeComponent,
    duplicateComponent,
    showPlaceholder,
    hidePlaceholder } from '../../actions';
import Structure from '../../components/Edit/Structure';

const mapStateToProps = state => ({
    components: state.template.components,
    selectedComponent: state.selection.selectedComponent,
    highlightedComponent : state.selection.highlightedComponent,
    hiddenComponent : state.selection.hiddenComponent,
    placeholderPath: state.selection.placeholderPath,
    showStructure: state.application.showStructure
});

const mapDispatchToProps = {
    selectComponent,
    highlightComponent,
    unhighlightComponent,
    addComponent,
    moveComponent,
    showPlaceholder,
    hidePlaceholder,
    removeComponent,
    duplicateComponent
};

export default connect(mapStateToProps, mapDispatchToProps)(Structure);