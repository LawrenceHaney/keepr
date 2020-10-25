<template>
  <div class="home container-fluid">
    <h1>Welcome</h1>
    <new-keep-form/>
  </div>
</template>

<script>
import newKeepForm from "../components/KeepForm"
export default {
  name: "home",
  mounted(){
    this.$store.dispatch("getKeeps")
  },
  components:{
    newKeepForm
  }
};
</script>
