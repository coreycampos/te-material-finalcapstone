<template>
  <div>
    <div id="nav" class="nav justify-content-center">
      <div id="left-corner">
        <img id="teLogo" src='../assets/images/TECircle.png' alt="Tech Elevator icon">
        <div id="partners">
          <span id="campos" class="name">Campos</span>
          <span id="hackett" class="name">Hackett</span>
          <span id="warren" class="name">Warren</span>
        </div>      
      </div>
      <div id="nav-links">
        <router-link class="nav-item" v-bind:to="{ name: 'home' }">
          <!-- <i class="fas fa-home"></i> This is a font awesome icon -->
          Home</router-link>
        <router-link
          class="nav-item"
          v-bind:to="{name: 'inventory'}">Inventory</router-link>
        <router-link
          class="nav-item"
          v-bind:to="{name: 'crops'}">Crops</router-link>
        <router-link 
          class="nav-item"
          v-bind:to="{name: 'AllDetails'}">All Crop Details</router-link>
        <router-link 
          class="nav-item"
          v-bind:to="{name: 'AllFarmInfo'}">All Farm Information</router-link>
        <router-link 
          class="nav-item"
          v-bind:to="{name: 'AddFarmInfo'}">Add Farming Information</router-link>
        <router-link 
          class="nav-item"
          v-bind:to="{name: 'uploadFiles'}">Upload Files</router-link>
        &nbsp;|&nbsp;
        <router-link
          class="nav-item"
          v-bind:to="{ name: 'register' }"
          v-if="!$store.state.token">Register</router-link>
        <router-link
          class="nav-item"
          v-bind:to="{ name: 'login' }"
          v-if="!$store.state.token">Login</router-link>
        <router-link
          class="nav-item"
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token">Logout</router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
#nav {
  background-color: whitesmoke;
  position: absolute;
  left: 0;
  right: 0;
  height: 4rem;
}
.nav-item {
  text-decoration: none;
  color: #333533;
  height: 100%;
  padding-left: .75rem;
  padding-right: .75rem;
  padding-top: 1rem;
  padding-bottom: 1.5rem;
}
.nav-item:hover {
  background-color: rgb(207, 207, 207);
}
#nav-links {
  padding-top: 1rem;
  padding-bottom: 1.5rem;
}
#left-corner {
  position: absolute;
  left: 1rem;
  top: .5rem;
  display: grid;
  grid-column-gap: 5px;
  grid-template-areas: 'logo name';
  grid-template-columns: 1fr, 1fr;
}
img {
  width:3rem;
  height:auto;
  grid-area: logo;
}
#campos {
  grid-area: campos;
}
#hackett {
  grid-area: hackett;
}
#warren {
  grid-area: warren;
}
.name {
  font-size: .6rem;
    grid-area: name;
    display: grid;
    grid-template-areas: "campos"
                         "hackett"
                         "warren";
}


</style>