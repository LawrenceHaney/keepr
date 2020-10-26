<template>
  <div class="container-fluid">
    <h1>Welcome: {{profile.name}}</h1>
  </div>
</template>

<script>
export default {
name:"Profile",
mounted(){
  this.$store.dispatch("getProfileById", this.$route.params.id)
},
computed:{
  profile(){
    return this.$store.state.focus
  }
}
}
</script>

<style>

</style>