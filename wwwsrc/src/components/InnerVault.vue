<template>
  <div v-bind:class="{active : index ==0}" class="carosuel-item">
      <img :src="keepData.img" class="d-block w-100" alt="...">
  </div>
</template>

<script>
export default {
  name: "InnerVault",
  props: ["keepData", "index"],

}
</script>

<style>

</style>