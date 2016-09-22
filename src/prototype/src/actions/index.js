export const REQUEST_POSTS = 'REQUEST_POSTS'
export const RECEIVE_POSTS = 'RECEIVE_POSTS'
export const SELECT_REDDIT = 'SELECT_REDDIT'
export const INVALIDATE_REDDIT = 'INVALIDATE_REDDIT'

export const selectReddit = reddit => ({
  type: SELECT_REDDIT,
  reddit
})

export const invalidateReddit = reddit => ({
  type: INVALIDATE_REDDIT,
  reddit
})

export const requestPosts = reddit => ({
  type: REQUEST_POSTS,
  reddit
})

export const receiveTemplate = (reddit, json) => ({
  type: RECEIVE_POSTS,
  reddit,
  posts: json.data.children.map(child => child.data),
  receivedAt: Date.now()
})

const fetchPosts = templatePatht => dispatch => {
  dispatch(requestTemplate(templatePath))
  return fetch(`${PROCESS.ENV.salesDataMartRoot}/_kola/templates?templatePath=${templatePath}`)
    .then(response => response.json())
    .then(json => dispatch(receiveTemplate(templatePath, json)))
}

const shouldFetchTemplate = (state, templatePath) => {
    return true;
}

export const fetchTemplateIfNeeded = templatePath => (dispatch, getState) => {
  if (shouldFetchTemplate(getState(), templatePath)) {
    return dispatch(fetchPosts(templatePath))
  }
}