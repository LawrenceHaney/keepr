<template>
<div class="d-inline">
<i class="fa fa-plus-square" aria-hidden="true" @click="openForm"></i>
<div class="modal fade" id="KeepForm" tabindex="-1">
  <div class="modal-dialog">
    <div class="modal-content bg-primary">
      <div class="modal-header">
        <h3 class="modal-title">Create a new Keep</h3>
  </div>
        <div class="modal-body row justify-content-start">
    <form @submit.prevent="createKeep" class="form-group p-2">
      <label for="Name">Name</label>
      <input type="text" name="name" v-model="newKeep.name" class="form-control" placeholder="name" aria-describedby="helpId">
      <small id="helpId" class="text-muted"></small>
      <label for="Description">Description</label>
      <input type="text" name="" id="" v-model="newKeep.description" class="form-control" placeholder="" aria-describedby="helpId">
      <small id="helpId" class="text-muted"></small>
      <label for="Image">Image</label>
      <input type="text" name="" id="" v-model="newKeep.img" class="form-control" placeholder="" aria-describedby="helpId">
      <small id="helpId" class="text-muted"></small>
      <button type="submit" class="btn btn-outline-light">Create Keep</button>
    </form>
</div>
</div>
</div>
</div>
</div>
  
</template>

<script>
export default {
  name: "newKeepForm",
  data(){
    return {
      newKeep: {}
    }
  },
  methods: {
    createKeep(){
      this.$store.dispatch("createKeep", this.newKeep)
      $('#KeepForm').modal('hide')
    },
    openForm(){
      $(`#KeepForm`).modal()
    }
  }

}
</script>

<style>

</style>