<template>
  <div class="card col">
    <router-link :to="{ name: 'Vault', params: {id: this.vaultData.id} }">
    <h1 class="card-title">{{vaultData.name}}</h1>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "VaultCard",
  props:["vaultData"]

}
</script>

<style>

</style>