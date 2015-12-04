var editorRegistry = require('app/EditorRegistry');
var textEditor = require('app/editors/TextEditor.jsx');
var markdownEditor = require('app/editors/MarkdownEditor.jsx');

editorRegistry.register('text', textEditor);
editorRegistry.register('markdown', markdownEditor);

