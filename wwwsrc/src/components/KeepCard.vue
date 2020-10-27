<template>
  <div @click="this.openModal" class="card col">
    <span v-if="keepData.img">
    <img class="card-img" :src="keepData.img">
    <div class="card-img-overlay row">
    <h1 class="col-12">{{keepData.name}}</h1>
    <div class="card">
      <img :src="keepData.creator.picture" alt="">
      <router-link :to="{ name: 'Profile', params: {id: this.keepData.creator.id} }"> {{keepData.creator.name}} </router-link>
    </div>
    </div>
    </span>
    <span v-else>
      <div class="row">

      <h1 class="col-12">{{keepData.name}}</h1>
      <div class="col-12">{{keepData.description}}</div>
      <div class="col-6">
      <img :src="keepData.creator.picture" alt="">
      <router-link :to="{ name: 'Profile', params: {id: this.keepData.creator.id} }"> {{keepData.creator.name}} </router-link>
      </div>
    </div>
    </span>
  <div class="modal fade" :id="keepData.id" tabindex="-1">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">{{keepData.name}}</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div v-if="keepData.img" class="modal-body">
      <img :src="keepData.img" class="card-img" alt="">
      </div>
      <div class="modal-footer">
        <p>{{keepData.description}}</p>
      </div>
      <div class="modal-footer">
        <div class="dropdown">
  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Add to Vault
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a v-for="vault in vaults" :key="vault.id" class="dropdown-item" @click.prevent="addToVault(vault.id)" >{{vault.name}}</a>
  </div>
</div>
      </div>
    </div>
  </div>
</div>
  </div>
  
</template>

<script>
export default {
  name:"keepCard",
  props:["keepData"],
  data(){
    return{
      newVaultKeep: {}
    }
  },
  computed:{
    vaults(){
      return this.$store.state.vaults
    }
  },
  methods:{
    openModal(){
      this.$store.dispatch("getVaultsByUser", this.$auth.userInfo.id)
      $(`#${this.keepData.id}`).modal()
    },
    addToVault(id){
      this.newVaultKeep.keepId = this.keepData.id
      this.newVaultKeep.vaultId = id
      this.$store.dispatch("addToVault", this.newVaultKeep)
    }
  }

}
</script>

<style>

</style>