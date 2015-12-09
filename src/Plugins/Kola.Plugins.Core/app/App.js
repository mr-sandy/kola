var editorRegistry = require('app/EditorRegistry');
var InputEditor = require('app/editors/InputEditor.jsx');
var TextareaEditor = require('app/editors/TextareaEditor.jsx');
var SelectBoxEditor = require('app/editors/SelectBoxEditor.jsx');
var RadioButtonEditor = require('app/editors/RadioButtonEditor.jsx');

editorRegistry.register('text', InputEditor, { type: 'text' });

editorRegistry.register('number', InputEditor, { type: 'number' });

editorRegistry.register('boolean', RadioButtonEditor, { options: ['true', 'false'] });

editorRegistry.register('multiline-text', TextareaEditor, { title: 'Multiline Text' });

editorRegistry.register('markdown', TextareaEditor, { title: 'Markdown' });

editorRegistry.register('html-style-type', SelectBoxEditor, { options: ['', 'text/css'] });

editorRegistry.register('ie-condition', SelectBoxEditor, { options: ['', 'lte8', 'gt8', 'lt9', '9', 'gt9'] });

editorRegistry.register('html-script-type', SelectBoxEditor, { options: ['', 'text/javascript'] });

editorRegistry.register('html-link-type', SelectBoxEditor, { options: ['', 'text/css', 'image/x-icon'] });

editorRegistry.register('html-link-rel-type', SelectBoxEditor, { options: ['', 'stylesheet', 'shortcut icon', 'apple-touch-icon'] });