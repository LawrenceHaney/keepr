<template>
  <div class="home container-fluid">
    <div class="row">
    <h1 class="m-4">Keeps
    <new-keep-form />
    </h1>
    </div>
    <div class="card-columns m-1">
      <keep-card calss="card" v-for="keep in keeps" :key= "keep.id" :keepData="keep"/>
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
