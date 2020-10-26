<template>
  <div class="card">
    <img class="card-img" v-if="keepData.img" :src="keepData.img">
    <div class="card-img-overlay row">
    <h1 class="col-12">{{keepData.name}}</h1>
    <div class="card col-6">
      <img :src="keepData.creator.picture" alt="">
      <router-link :to="{ name: 'Profile', params: {id: this.keepData.creator.id} }"> {{keepData.creator.name}} </router-link>
    </div>
    </div>
  </div>
</template>

<script>
export default {
  name:"keepCard",
  props:["keepData"],


}
</script>

<style>

</style>