import { connect } from 'react-redux';
import Properties from '../../components/Edit/Properties';
import { selectedComponentProperties } from '../../selectors';
import { selectProperty, setProperty, setPropertyValueType, setPropertyValue } from '../../actions';

const mapStateToProps = state => ({
    //components: state.template.components,
    //highlightedComponent : state.selection.highlightedComponent,
    //hiddenComponent : state.selection.hiddenComponent,
    //placeholderPath: state.selection.placeholderPath,
    componentPath: state.selection.selectedComponent,
    showProperties: state.application.showProperties,
    properties: selectedComponentProperties(state)
});

const mapDispatchToProps = {
    selectProperty,
    setProperty,
    setPropertyValueType,
    setPropertyValue
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