import { RECEIVE_TEMPLATE, RECEIVE_COMPONENT } from '../actions';

const replaceComponent = (componentPath, component, replacement ) => {
    if (componentPath.length === 0) {
        return replacement;
    } else {
        switch (component.type) {
        case 'widget':
            return{
                ...component,
                areas: [
                    ...component.areas.slice(0, componentPath[0]),
                    replaceComponent(componentPath.slice(1), component.areas[componentPath[0]], replacement),
                    ...component.areas.slice(componentPath[0] + 1)
                ]
            };
        case 'container':
        default:
            return{
                ...component,
                components: [
                    ...component.components.slice(0, componentPath[0]),
                    replaceComponent(componentPath.slice(1), component.components[componentPath[0]], replacement),
                    ...component.components.slice(componentPath[0] + 1)
                ]
            };
        }
    }
};

const template = (state = {}, action) => {
    switch(action.type) {
        case RECEIVE_TEMPLATE:
            return action.payload;

        case RECEIVE_COMPONENT:
        {
            const componentPath = action.payload.path.split('/').filter(s => s).map(s => parseInt(s, 10));
            return replaceComponent(componentPath, state, action.payload);
        }

        default:
            return state;
    }
}

export default template;