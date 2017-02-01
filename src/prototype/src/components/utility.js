
export const loadEditor = propertyType => {
    const editor = kola.propertyEditors.find(ed => ed.propertyType === propertyType);

    if (!editor) {
        console.log('No editor for property type ' + propertyType);
    }

    return editor;
}