<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.0/components/alerts/ for reference on bootstrap -->


<template>
  <div id="app" class="container">
    <nav-bar class="nav"/>
    <div class="routerView">
      <router-view/>
    </div>
  </div>
</template>

<script>
import NavBar from "./components/NavBar.vue"

export default {
  components: {
    NavBar,
  }
}
</script>

<!-- Application-Wide Styles go here -->
<style>
div{
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}
table{
  background-color: #E8EDDF;
  border-radius: 10px;
  margin-top: .5rem;
}
h2 {
  padding-top: 1rem;
}

.nav {
  z-index: 999999 !important;
  padding-bottom: 4rem;
}


</style>