<template>
  <div class="card col">
    <router-link :to="{ name: 'Vault', params: {id: this.vaultData.id} }">
    <h1 class="card-title">{{vaultData.name}}</h1>
    </router-link>
    <div :id="vaultData.id" class="carousel slide">
      <div class="carousel-inner">
        <inner-vault v-for="(keep, index) in keeps[this.vaultData.id]" :key= "keep.id" :keepData="keep" :index="index"/>
    </div>
    </div>
  </div>
</template>

<script>
import InnerVault from "../components/InnerVault"
export default {
  name: "VaultCard",
  props:["vaultData"],
  computed:{
    keeps(){
      return this.$store.state.dict
    }
  },
  mounted(){
  this.$store.dispatch("getKeepsbyVaultIdCard", this.vaultData.id)
  setTimeout(($('.carousel').carousel()), 1000)
},

components:{
  InnerVault
}

}
</script>

<style>

</style>