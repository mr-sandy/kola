import { connect } from 'react-redux';
import { selectComponent, highlightComponent, unhighlightComponent, addComponent, moveComponent, showPlaceholder, hidePlaceholder } from '../../actions';
import Structure from '../../components/Edit/Structure';

const getTemplatePath = template => template.links ? template.links.find(l => l.rel === 'path').href : '';

const mapStateToProps = state => ({
    components: state.template.components,
    templatePath: getTemplatePath(state.template),
    selectedComponent: state.selection.selectedComponent,
    highlightedComponent : state.selection.highlightedComponent,
    hiddenComponent : state.selection.hiddenComponent,
    placeholderPath: state.selection.placeholderPath
});

const mapDispatchToProps = {
    selectComponent,
    highlightComponent,
    unhighlightComponent,
    addComponent,
    moveComponent,
    showPlaceholder,
    hidePlaceholder
};

export default connect(mapStateToProps, mapDispatchToProps)(Structure);