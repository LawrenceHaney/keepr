<template>
  <div class="container-fluid">
    <div class="row my-3">
    <img class="p-2" :src="profile.picture" alt="">
    <h1 class="col-12 mb-5"><span v-if="this.$auth.userInfo.Id == this.$route.params.id">Welcome: </span>{{profile.name}}</h1>
    <h1 class="col-3">Vaults:
    {{vaults.length}}
    <new-vault-form/>
    </h1>
    <div class="card-columns">
    <vault-card v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
    </div>
    </div>
    <hr>
    <div class="row my-3">
    <h1 class="col-3">Keeps: {{keeps.length}}
    <new-keep-form/>
    </h1>
    <div class="card-columns">
      <keep-card v-for="keep in keeps" :key= "keep.id" :keepData="keep"/>
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
  this.$store.dispatch("getKeepsByUser", this.$route.params.id)
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