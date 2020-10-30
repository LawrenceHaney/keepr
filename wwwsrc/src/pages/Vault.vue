<template>
  <div class="container-fluid">
    <div class="row">
      <h1 class="col-12 img-title">{{vault.name}}</h1>
      <h6 class="col-12 img-title">{{vault.description}} 
        <div class="close">
          <i class="fa fa-trash img-title" @click="deleteVault(vault.id)" aria-hidden="true"></i>
        </div>
      </h6>
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
}, 
methods: {
  deleteVault(id){
    console.log(id);
    let res = confirm("can't undo this, are you sure?")
      if(res == true)
      this.$store.dispatch("deleteVault", id)
      this.$router.push({ name: "Home" })
  }
}

}
</script>

<style>

</style>