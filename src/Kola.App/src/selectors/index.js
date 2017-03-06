import { selectComponent, toIntArray } from '../utility';

export const selectedComponent = state => {
    const selectedComponentPath = state.selection.selectedComponent;

    return (selectedComponentPath)
        ? selectComponent(state.template, toIntArray(selectedComponentPath))
        : null;
}

export const selectedComponentProperties = state => {
    const selectedComponentPath = state.selection.selectedComponent;

    if (!selectedComponentPath) {
        return [];
    }

    const selectedComponent = selectComponent(state.template, toIntArray(selectedComponentPath));
    const selectedPropertyName = state.selection.selectedProperty;

    return selectedComponent.properties.map(p => ({
        ...p,
        selected: p.name === selectedPropertyName
    }));
}