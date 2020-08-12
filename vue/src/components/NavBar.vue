<template>
  <div id="app" class="container">
    <div id="nav">
      <router-link class="nav-item" v-bind:to="{ name: 'home' }">
        <i class="fas fa-home"></i> <!-- This is a font awesome icon -->
        Home</router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token">&nbsp;|&nbsp;Register</router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token">
        &nbsp;|&nbsp;Login</router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token">
        &nbsp;|&nbsp;Logout</router-link>
      <router-link
        class="nav-item"
        v-bind:to="{name: 'crops'}">
        &nbsp;|&nbsp;Crops</router-link>
      <router-link 
        class="nav-item"
        v-bind:to="{name: 'AllDetails'}">
        &nbsp;|&nbsp;All Crop Details</router-link>
      <router-link 
        class="nav-item"
        v-bind:to="{name: 'uploadFiles'}">
        &nbsp;|&nbsp;Upload Files</router-link>
      <router-link 
        class="nav-item"
        v-bind:to="{name: 'AllFarmInfo'}">
        &nbsp;|&nbsp;All Farm Information</router-link>
      <router-link 
        class="nav-item"
        v-bind:to="{name: 'AddFarmInfo'}">
        &nbsp;|&nbsp;Add Farming Information</router-link>
    </div>
    <router-view />
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>