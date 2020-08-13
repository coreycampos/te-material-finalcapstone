<template>
  <div>
    <inventory-info v-bind:inventories="$store.state.inventory" />
  </div>
</template>

<script>
import InventoryInfo from "../components/InventoryInfo.vue"
import InventoryDataService from "../services/InventoryDataService.js"

export default { 
  components: {
    InventoryInfo,
  },
  created() {
        InventoryDataService.getInventoryData()
        .then(response => {
            this.$store.commit("POPULATE_INVENTORY", response.data);
        })
        .catch(error => {
            console.error(error);
            //alert("Error - see console.");
            });    
  }
}  
</script>

<style scoped>

</style>