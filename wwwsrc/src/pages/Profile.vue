<template>
  <div class="container-fluid">
    <h1>Welcome: {{profile.name}}</h1>
    <new-vault-form/>
  </div>
</template>

<script>
import newVaultForm from "../components/VaultForm.vue"
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
  Vaults(){
    return this.$store.state.vaults
  }
},
components:{
    newVaultForm
}
}
</script>

<style>

</style>