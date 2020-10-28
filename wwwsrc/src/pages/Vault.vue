<template>
  <div class="container-fluid">
    <div class="row">
      <h1 class="col-12">{{vault.name}}</h1>
      <h6 class="col-12">{{vault.description}}</h6>
    </div>
    <div class="card-columns">
      <keep-card v-for="keep in keeps" :key= "keep.id" :keepData="keep"/>
    </div>
  </div>
</template>

<script>
import keepCard from "../components/KeepCard.vue"
export default {
  name: "Vault",
mounted(){
  this.$store.dispatch("getVaultById", this.$route.params.id)
  this.$store.dispatch("getKeepsbyVaultId", this.$route.params.id)
},
computed:{
  vault(){
    return this.$store.state.focus
  },
  keeps(){
    return this.$store.state.keeps
  }
},
components:{
    keepCard
}
}
</script>

<style>

</style>