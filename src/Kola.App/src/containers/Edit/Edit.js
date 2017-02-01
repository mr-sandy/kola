import { connect } from 'react-redux';
import { fetchTemplate } from '../../actions';
import Edit from '../../components/Edit';
import { initialiseOnMount } from '../helpers/higherOrderComponents';

const mapStateToProps = state => ({
    template: state.template
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    initialise: () => dispatch(fetchTemplate(ownProps.location.query.templatePath))
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Edit));