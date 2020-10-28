<template>
  <div class="container-fluid">
    <h1>Welcome: {{profile.name}}</h1>
    <new-vault-form/>
    <div class="grid" data-isotope='{ "itemSelector": ".grid-item", "layoutMode": "fitRows" }'>
    <vault-card class="grid-item" v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
    </div>
  </div>
</template>

<script>
import newVaultForm from "../components/VaultForm.vue"
import VaultCard from "../components/VaultCard.vue"
export default {
name:"Profile",
mounted(){
  this.$store.dispatch("getProfileById", this.$route.params.id)
  this.$store.dispatch("getVaultsByUser", this.$route.params.id)
},
computed:{
  profile(){
    return this.$store.state.focus
  },
  vaults(){
    return this.$store.state.vaults
  }
},
components:{
    newVaultForm,
    VaultCard
}
}
</script>

<style>

</style>