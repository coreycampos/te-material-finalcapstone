<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.0/components/alerts/ for reference on bootstrap -->


<template>
  <div id="nav">
    <nav-bar/>    
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

</style>