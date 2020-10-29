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
    dict: {},
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
    },
    setVaults(state, vaults){
      state.vaults = vaults
    },
    setDict(state, payload){
      state.dict = payload
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

      async getKeepsByUser({commit}, user){
        try {
          let res = await api.get("keeps/" +user+"/user" )
          commit("setKeeps", res.data)
        } catch (error) {
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
      async deleteKeep({commit, state}, id){
        try {
          await api.delete("keeps/"+id)
          commit("setKeeps", [...state.keeps.filter(k=> k.id != id)])
        } catch (error) {
          console.error(error)
        }
      },
      async updateViews({commit, state}, id){
        try {
          await api.put("keeps/"+id+"/views")
        } catch (error) {
          console.error(error)
        }
      },

      async addToVault({commit, state}, newVaultKeep){
        try {
          let res = await api.post("vaultkeeps", newVaultKeep)
        } catch (error) {
          console.error(error)
        }
      },

      async getKeepsbyVaultId({commit, state}, id){
        try {
          let res = await api.get("vaults/" +id+ "/keeps")
          commit("setKeeps", res.data)
        } catch (error) {
          console.error(error)
        }
      },
      async getKeepsbyVaultIdCard({commit, state}, id){
        try {
          let res = await api.get("vaults/" +id+ "/keeps")
          let payload = state.dict
          payload[id] = res.data
          console.log(payload);
          commit("setDict", payload)
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

      async getVaultsByUser({commit, state}, userId){
        try {
            let res = await api.get("vaults/"+ userId +"/user")
            commit("setVaults", [...res.data]);
        } catch (error) {
          console.error(error)
        }
      },
      async getVaultById({commit, state}, id){
        try {
          let res = await api.get("vaults/"+ id)
          commit("setFocus", res.data);
      } catch (error) {
        console.error(error)
      }
      },

      async deleteVault({commit}, id){
      try {
        let res= await api.delete("vaults/" + id)
      } catch (error) {
        console.error(error)
      }
    }
    }
  }
);
