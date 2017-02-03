import { connect } from 'react-redux';
import { fetchTemplate, selectComponent, highlightComponent } from '../../actions';
import Edit from '../../components/Edit';
import { initialiseOnMount } from '../helpers/higherOrderComponents';

const mapStateToProps = state => ({
    template: state.template,
    selectedComponent: state.selection.selectedComponent,
    highlightedComponent : state.selection.highlightedComponent
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    initialise: () => dispatch(fetchTemplate(ownProps.location.query.templatePath)),
    selectComponent: componentPath => dispatch(selectComponent(componentPath)),
    highlightComponent: componentPath => dispatch(highlightComponent(componentPath))
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Edit));