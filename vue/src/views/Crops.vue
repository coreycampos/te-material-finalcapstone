<template>
  <div>
    <Home-Crops />
  </div>
</template>

<script>
import HomeCrops from "../components/HomeCrops.vue"
import CropDataService from "../services/CropDataService.js"

export default {
  components: {
    HomeCrops
    },
  created() {
    CropDataService.getCropData()
    .then(response => {
      this.$store.commit("POPULATE_CROP_DATA", response.data);
    })
    .catch(error => {
      // if (error.response.status == '404') {
      //   this.$router.push("/not-found");
      // }
      console.error(error);
      alert("Error - see console.");
    });
  }
};
</script>

<style scoped>

</style>