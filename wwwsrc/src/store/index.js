import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
  },
  actions: {
    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeeps({commit}) {
        try {
          let res = await api.get("keeps");
          console.log(res)
        } 
        catch (error) {
          console.error(error)
        }
      },
      async createKeep({commit, state}, newKeep){
        try {
          let res = await api.post("keeps", newKeep)
          console.log(res) 
        } catch (error) {
          console.error(error)
        }
      }
    }
  }
);
