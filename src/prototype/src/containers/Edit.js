import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router';
import Toolbox from '../components/Toolbox';
import Structure from '../components/Structure';
import Properties from '../components/Properties';
import Preview from '../components/Preview';
import { fetchTemplateIfNeeded, selectComponent, selectComponentByPath, selectProperty } from '../actions';

class Edit extends Component {

    componentDidMount() {
        const { dispatch, templatePath } = this.props;
        dispatch(fetchTemplateIfNeeded(templatePath));
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.templatePath !== this.props.templatePath) {
            const { dispatch, templatePath } = nextProps;
            dispatch(fetchTemplateIfNeeded(templatePath));
        }
    }

    render() {
        const {
            templatePath,
            template,
            onComponentSelect,
            onComponentSelectByPath,
            onPropertySelect,
            selectedComponent,
            selectedProperty,
            previewUrl } = this.props;

        return (
            <div>
                <Link className="mainNav" to="/">Home</Link>
                <Toolbox />
                <Structure template={template} onClick={onComponentSelect} selectedComponent={selectedComponent} />
                <Properties component={selectedComponent} onPropertySelect={onPropertySelect} selectedProperty={selectedProperty} />
                <Preview url={previewUrl} onClick={onComponentSelectByPath} selectedComponent={selectedComponent} />
            </div>
        )
    }
}

const mapStateToProps = (state, ownProps) => ({
    template: state.template.template,
    templatePath: ownProps.location.query.templatePath,
    selectedComponent: state.selection.selectedComponent,
    selectedProperty: state.selection.selectedProperty,
    previewUrl: state.template.template.links ? state.template.template.links.find(l => l.rel === 'preview').href : ''
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    dispatch,
    onComponentSelect: component => dispatch(selectComponent(component)),
    onComponentSelectByPath: componentPath => dispatch(selectComponentByPath(componentPath)),
    onPropertySelect: property => dispatch(selectProperty(property))
});

export default connect(mapStateToProps, mapDispatchToProps)(Edit);
