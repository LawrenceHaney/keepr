import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    focus: {},
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setFocus(state, payload){
      state.focus = payload
    },
    setKeeps(state, keeps){
      state.keeps = keeps
    }
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
    async getProfileById({commit}, id){
      try {
        let res = await api.get("profiles/"+ id)
        commit("setFocus", res.data)
      } catch (error) {
        
      }
    },
    async getKeeps({commit}) {
        try {
          let res = await api.get("keeps");
          console.log(res);
          commit("setKeeps", res.data)
          console.log(this.state.keeps);
        } 
        catch (error) {
          console.error(error)
        }
      },
      async createKeep({commit, state}, newKeep){
        try {
          console.log(newKeep);
          let res = await api.post("keeps", newKeep)
          console.log(res) 
        } catch (error) {
          console.error(error)
        }
      }
    }
  }
);
