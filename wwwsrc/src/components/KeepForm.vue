<template>
  <div class="row">
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
      <button type="submit" class="btn btn-outline-primary">GO!</button>
    </form>
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
      this.$store.dispatch("createKeep")
    }
  }

}
</script>

<style>

</style>