<template>
<div class="col-1 d-inline">
<i class="fa fa-plus-square" aria-hidden="true" @click="openForm"></i>
<div class="modal fade" id="VaultForm" tabindex="-1">
  <div class="modal-dialog">
    <div class="modal-content bg-primary">
      <div class="modal-header">
        <h5 class="modal-title">Create a new Vault</h5>
  </div>
  <div class="modal-body d-flex flex-column">
    <form @submit.prevent="createVault" class="form-group p-2">
      <label for="Name">Name</label>
      <input type="text" name="name" v-model="newVault.name" class="form-control" placeholder="name" aria-describedby="helpId">
      <label for="Description">Description</label>
      <input type="text" name="" id="" v-model="newVault.description" class="form-control" placeholder="" aria-describedby="helpId">
      <label for="Privacy">Private</label>
      <input type="checkbox" class="m-1" v-model="newVault.IsPrivate" aria-label="Checkbox for following text input">
      <hr>
      <button type="submit" class="btn btn-outline-dark">Create Vault</button>
    </form>
  </div>
</div>
</div>
</div>
</div>
</template>

<script>
export default {
  name: "newVaultForm",
  data(){
    return {
      newVault: {}
    }
  },
  methods: {
    createVault(){
      this.$store.dispatch("createVault", this.newVault)
      $('#VaultForm').modal('hide')
    },
    openForm(){
      $(`#VaultForm`).modal()
    }
  }

}
</script>

<style>

</style>