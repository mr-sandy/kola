import { connect } from 'react-redux';
import { fetchComponents } from '../actions';
import Toolbox from '../components/Toolbox';
import { initialiseOnMount } from './helpers/higherOrderComponents';

const mapStateToProps = (state, ownProps) => ({
    //productPurchaseInformation: state.productPurchaseInformation,
    //orderUrl: ownProps.location.query.orderUrl
});

const mapDispatchToProps = dispatch => ({
    initialise: () => dispatch(fetchComponents())
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Toolbox));