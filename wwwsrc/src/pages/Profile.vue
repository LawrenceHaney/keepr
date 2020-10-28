<template>
  <div class="container-fluid">
    <div class="row my-3">
    <h1 class="col-12 my-5">Welcome: {{profile.name}}</h1>
    <h1 class="col-3">Vaults</h1>
    <new-vault-form/>
    <div class="grid" data-isotope='{ "itemSelector": ".grid-item", "layoutMode": "fitRows" }'>
    <vault-card class="grid-item" v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
    </div>
    </div>
    <hr>
    <div class="row my-3">
    <h1 class="col-3">Keeps</h1>
    <new-keep-form/>
    <div class="grid" data-isotope='{ "itemSelector": ".grid-item", "layoutMode": "fitRows" }'>
      <keep-card class="grid-item" v-for="keep in keeps" :key= "keep.id" :keepData="keep"/>
    </div>
    </div>
  </div>
</template>

<script>
import newVaultForm from "../components/VaultForm.vue"
import VaultCard from "../components/VaultCard.vue"
import newKeepForm from "../components/KeepForm"
import keepCard from "../components/KeepCard"
export default {
name:"Profile",
mounted(){
  this.$store.dispatch("getProfileById", this.$route.params.id)
  this.$store.dispatch("getVaultsByUser", this.$route.params.id)
  this.$store.dispatch("getKeepsbyUser", this.$route.params.id)
},
computed:{
  profile(){
    return this.$store.state.focus
  },
  vaults(){
    return this.$store.state.vaults
  },
  keeps(){
    return this.$store.state.keeps
  }
},
components:{
    newVaultForm,
    VaultCard,
    newKeepForm,
    keepCard
}
}
</script>

<style>

</style>