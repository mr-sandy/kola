const initialState = [
    { name: 'Component 1' },
    { name: 'Component 2' },
    { name: 'Component 3' },
    { name: 'Component 4' }
];

export default function components(state = initialState, action) {
    switch (action.type) {
        default:
            return state;
    }
}