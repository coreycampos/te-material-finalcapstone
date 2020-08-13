<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.0/components/alerts/ for reference on bootstrap -->


<template>
  <div id="app" class="container">
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
div{
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}
/* table{
  background-color: rgba(188, 253, 188, 0.712);
  border-radius: 10px;
} */
</style>