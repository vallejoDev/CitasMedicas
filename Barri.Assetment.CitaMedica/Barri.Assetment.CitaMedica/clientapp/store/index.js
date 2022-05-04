export const state = () => ({
  games: []
})

export const actions = {
}

export const mutations = {
  storeGames(state, games) {
    state.games = [...games]
  }
}
