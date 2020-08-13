<template>
  <div id="homeContainer">
    <h1 class="appTitle" id="title">FarmAssistant</h1>
    <h2 class="appTitle" id="subTitle">Facilitating Small Scale Agriculture</h2>
  </div>
</template>

<script>
export default { 

}  
</script>

<style scoped>
#homeContainer {
  background-image: url('../assets/images/HomeViewImage.jpg');
  background-repeat: no-repeat;
  background-size: cover;
  background-attachment: fixed;
  height : 100vh;
  width : 100vw;
  position: fixed;
  top: 0;
  left: 0;
  /* opacity: .7; */
  display: grid;
  grid:
    '...'
    '...'
    'Title'
    'subTitle'
    '...'
    '...';
}

.appTitle {
  color: whitesmoke;
  /* text-shadow: 5px 5px 0 black; */
  font-family: 'Raleway', sans-serif;
  text-align: center;
  vertical-align: bottom;
}
#title {
   font-size: 1000%;
   grid-area: Title;
}
#subTitle {
  font-size: 500%;
  grid-area: subTitle;
}

</style>
