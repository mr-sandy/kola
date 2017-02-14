
export const toIntArray = componentPath => componentPath.split('/').filter(s => s).map(s => parseInt(s, 10));