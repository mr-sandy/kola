import { connect } from 'react-redux';
//import { fetchOrder } from '../actions';
import Edit from '../components/Edit';
import { initialiseOnMount } from './helpers/higherOrderComponents';

const mapStateToProps = (state, ownProps) => ({
    //productPurchaseInformation: state.productPurchaseInformation,
    //orderUrl: ownProps.location.query.orderUrl
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    //initialise: () => dispatch(fetchOrder(ownProps.location.query.orderUrl))
});

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Edit));