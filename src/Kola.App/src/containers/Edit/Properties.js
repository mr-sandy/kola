import { connect } from 'react-redux';
import Properties from '../../components/Edit/Properties';
import { selectedComponentProperties } from '../../selectors';
import { selectProperty } from '../../actions';

const mapStateToProps = state => ({
    //components: state.template.components,
    //selectedComponent: state.selection.selectedComponent,
    //highlightedComponent : state.selection.highlightedComponent,
    //hiddenComponent : state.selection.hiddenComponent,
    //placeholderPath: state.selection.placeholderPath,
    showProperties: state.application.showProperties,
    properties: selectedComponentProperties(state)
});

const mapDispatchToProps = {
    selectProperty

    //highlightComponent,
    //unhighlightComponent,
    //addComponent,
    //moveComponent,
    //showPlaceholder,
    //hidePlaceholder,
    //removeComponent,
    //duplicateComponent
};

export default connect(mapStateToProps, mapDispatchToProps)(Properties);