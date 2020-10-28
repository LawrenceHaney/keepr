<template>
<div class="col-1">
<i class="fa fa-plus-square" aria-hidden="true" @click="openForm"></i>
<div class="modal fade" id="VaultForm" tabindex="-1">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Create a new Vault</h5>
  <div class="row">
    <form @submit.prevent="createVault" class="form-group p-2">
      <label for="Name">Name</label>
      <input type="text" name="name" v-model="newVault.name" class="form-control" placeholder="name" aria-describedby="helpId">
      <label for="Description">Description</label>
      <input type="text" name="" id="" v-model="newVault.description" class="form-control" placeholder="" aria-describedby="helpId">
      <label for="Privacy">Private?</label>
      <input type="checkbox" v-model="newVault.IsPrivate" aria-label="Checkbox for following text input">
      <button type="submit" class="btn btn-outline-primary">GO!</button>
    </form>
  </div>
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
    },
    openForm(){
      $(`#VaultForm`).modal()
    }
  }

}
</script>

<style>

</style>