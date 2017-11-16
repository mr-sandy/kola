import { selectComponent, toIntArray } from '../utility';

export const selectedComponent = state => {
    const selectedComponentPath = state.selection.selectedComponent;

    return (selectedComponentPath)
        ? selectComponent(state.template, toIntArray(selectedComponentPath))
        : null;
}

export const selectedComponentProperties = ({template, selection}) => {
    const { selectedComponent, selectedProperty } = selection;

    if (!selectedComponent) {
        return [];
    }

    const component = selectComponent(template, toIntArray(selectedComponent));

    return component.properties.map(p => selectedProperty && selectedProperty.name === p.name
        ? { ...selectedProperty, selected: true }
        : { ...p, selected: false });
}