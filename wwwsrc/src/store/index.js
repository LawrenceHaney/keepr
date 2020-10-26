import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    focus: {},
    vaults: [],
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
          let res = await api.post("keeps", newKeep)
          commit("setKeeps", [...state.keeps, res.data]) 
        } catch (error) {
          console.error(error)
        }
      },
      
      async createVault({commit, state}, newVault){
        try {
          let res = await api.post("vaults", newVault)
          commit("setVaults", [...state.vaults, res.data])
        } catch (error) {
          console.error(error)
        }
      },
    }
  }
);
