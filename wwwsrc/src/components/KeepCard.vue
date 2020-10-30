<template>
  <div @click="this.openModal" class="card keep-card m-3 p-1 bg-secondary">
    <span v-if="keepData.img">
    <img class="card-img" :src="keepData.img">
    <div class="card-img-overlay d-flex flex-column justify-content-between">
    <div></div>
    <div class="row justify-content-between">
    <h1 class="p-4 img-title">{{keepData.name}}</h1>
    <div class="profile-elm">
      <div v-on:click.stop="gotoprofile">
      <img class="profile-img p-1" :src="keepData.creator.picture" alt="">
      </div>
    </div>
    </div>
    </div>
    </span>
    <span v-else>
      <div class="row">

      <h1 class="col-12">{{keepData.name}}</h1>
      <div class="col-12">{{keepData.description}}</div>
      <div class="col-6 .profile-elm">
      <div v-on:click.stop="gotoprofile"> 
      <img class="profile-img" :src="keepData.creator.picture" alt="">
      </div>
      </div>
    </div>
    </span>
  <div class="modal fade" :id="keepData.id" tabindex="-1">
  <div class="modal-dialog">
    <div class="modal-content container-fluid bg-secondary">
      <div class="modal-header">
        <div class="d-flex flex-column">
        <h5 class="modal-title">{{keepData.name}}</h5>
        <small>Views: {{keepData.views}}  Keeps: {{keepData.keeps}}</small>
        </div>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
      <div class="row justify-content-around">
      <div v-if="keepData.img" class="col-6">
      <img :src="keepData.img" class="card-img" alt="">
      </div>
      <div class="col-6 d-flex flex-column justify-content-between">
        <div class="row">
          <div class="col-12">

        <div class="close"  v-if='this.$route.name == "Vault"' >
          <small>remove</small>
          <i class="fa fa-minus-square" @click="removeFromVault()" aria-hidden="true"></i>
        </div>
        <div class="close">
          <small>delete</small>
          <i class="fa fa-trash" @click="deleteKeep(keepData.id)" aria-hidden="true"></i>
        </div>
        <p class="text-center">{{keepData.description}}</p>
        </div>
        </div>
        <div class="row">
      <div class="col-6">
        <div class="dropdown">
          <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          Add to Vault
          </button>
            <div class="dropdown-menu bg-primary img-title drop-scroll" aria-labelledby="dropdownMenuButton">
            <a v-for="vault in vaults" :key="vault.id" class="dropdown-item" @click.prevent="addToVault(vault.id)" >{{vault.name}}</a>
            </div>
        </div>
        </div>
        <div class="col-4">
        <div class="" v-on:click.stop="gotoprofile"> 
        <img class="profile-img" :src="keepData.creator.picture" alt="">
          {{keepData.creator.name}}
        </div>
      </div>
      </div>
      </div>
      </div>
      </div>
      <div class="modal-footer justify-content-between">
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
    gotoprofile(){
      $(`#${this.keepData.id}`).modal('hide')
      this.$router.push({ name: 'Profile', params: {id: this.keepData.creator.id} })
    },
    openModal(){
      this.keepData.views ++
      this.$store.dispatch("getVaultsByUser", this.$auth.userInfo.id)
      this.$store.dispatch("updateViews", this.keepData.id)
      $(`#${this.keepData.id}`).modal()
    },
    addToVault(id){
      this.newVaultKeep.keepId = this.keepData.id
      this.newVaultKeep.vaultId = id
      this.$store.dispatch("addToVault", this.newVaultKeep)
      $(`#${this.keepData.id}`).modal('hide')
    },
    deleteKeep(id){
      let res = confirm("can't undo this, are you sure?")
      if(res == false)
        {return}
      else
      {
        this.$store.dispatch("deleteKeep", id)
        $(`#${this.keepData.id}`).modal('hide')
      }
    },
    removeFromVault(){
      let res = confirm("can't undo this are you sure?")
      if (res== true)
        {
          this.$store.dispatch("deleteKeepFromVault", this.keepData.vaultKeepId)
          $(`#${this.keepData.id}`).modal('hide')
        }
    }
  }

}
</script>

<style>

</style>