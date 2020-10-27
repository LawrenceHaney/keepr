<template>
  <div class="container-fluid">
    <div class="row">
      <h1>{{vault.name}}</h1>
      <h6>{{vault.description}}</h6>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
mounted(){
  this.$store.dispatch("getVaultById", this.$route.params.id)
},
computed:{
  vault(){
    return this.$store.state.focus
  }
}
}
</script>

<style>

</style>