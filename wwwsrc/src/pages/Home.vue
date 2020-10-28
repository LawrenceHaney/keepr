<template>
  <div class="home container-fluid">
    <div class="row">
    <div class="card col-10">
    <h1 @click="openForm()">Welcome</h1>
    <new-keep-form/>
    </div>
    </div>
    <div class="grid" data-isotope='{ "itemSelector": ".grid-item", "layoutMode": "fitRows" }'>
      <keep-card class="grid-item" v-for="keep in keeps" :key= "keep.id" :keepData="keep"/>
    </div>
  </div>
</template>

<script>
import newKeepForm from "../components/KeepForm"
import keepCard from "../components/KeepCard"
export default {
  name: "home",
  computed:{
    keeps(){
      return this.$store.state.keeps
    }
  },
  mounted(){
    this.$store.dispatch("getKeeps")
  },
  components:{
    newKeepForm,
    keepCard
  }
};
</script>
