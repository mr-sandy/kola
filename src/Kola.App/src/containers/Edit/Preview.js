import { connect } from 'react-redux';
//import { selectComponent, highlightComponent } from '../../actions';
import Preview from '../../components/Edit/Preview';

const getPreviewUrls = template => {
    return template.links
        ? template.links.filter(l => l.rel === 'preview').map(l => l.href)
        : [];
}

const mapStateToProps = state => ({
    previewUrls: getPreviewUrls(state.template)
});

const mapDispatchToProps = {
};

export default connect(mapStateToProps, mapDispatchToProps)(Preview);