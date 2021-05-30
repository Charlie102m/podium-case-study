import { createStore } from "vuex";
import { State, Mutations } from "@/types";

const state: State = { token: "", isAuthenticated: false };

export default createStore({
  state,
  mutations: {
    AUTHENTICATE(state, payload) {
      state.token = payload;
      state.isAuthenticated = true;
    },
    LOGOUT(state) {
      state.token = "";
      state.isAuthenticated = false;
    },
  },
  actions: {
    authenticate({ commit }, payload) {
      commit(Mutations.Authenticate, payload);
    },
    logout({ commit }) {
      commit(Mutations.Logout);
    },
  },
});
