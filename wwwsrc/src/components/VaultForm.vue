<template>
  <div class="row">
    <form @submit.prevent="createVault" class="form-group p-2">
      <label for="Name">Name</label>
      <input type="text" name="name" v-model="newVault.name" class="form-control" placeholder="name" aria-describedby="helpId">
      <small id="helpId" class="text-muted"></small>
      <label for="Description">Description</label>
      <input type="text" name="" id="" v-model="newVault.description" class="form-control" placeholder="" aria-describedby="helpId">
      <small id="helpId" class="text-muted"></small>
      <button type="submit" class="btn btn-outline-primary">GO!</button>
    </form>
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
    }
  }

}
</script>

<style>

</style>