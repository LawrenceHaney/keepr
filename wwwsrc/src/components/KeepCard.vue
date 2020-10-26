<template>
  <div class="card">
    <img class="card-img" v-if="keepData.img" :src="keepData.img">
    <div class="card-img-overlay">
    <h1>{{keepData.name}}</h1>
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