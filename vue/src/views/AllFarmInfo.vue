<template>
    <div>
        <plan-info v-bind:plans="$store.state.cropPlans" />
        <button>Edit</button>
        <harvest-info v-bind:harvests="$store.state.harvests" />
        <button>Edit</button>
        <sales-info v-bind:sales="$store.state.sales" />
        <button>Edit</button>
        <loss-info v-bind:losses="$store.state.losses" />
        <button>Edit</button>
        <waste-info v-bind:wastes="$store.state.wastes" />
        <button>Edit</button>
    </div>
</template>

<script>
import SalesInfo from "../components/SalesInfo.vue"
import PlanInfo from "../components/PlanInfo.vue"
import LossInfo from "../components/LossInfo.vue"
import HarvestInfo from "../components/HarvestInfo.vue"
import WasteInfo from "../components/WasteInfo.vue"

import CropPlansService from "../services/CropPlansService.js"
import HarvestDataService from "../services/HarvestDataService.js"
import SaleDataService from "../services/SaleDataService.js"
import LossDataService from "../services/LossDataService.js"
import WasteDataService from "../services/WasteDataService.js"

export default {
    components: {
        SalesInfo,
        PlanInfo,
        LossInfo,
        HarvestInfo,
        WasteInfo
    },
    created() {
        CropPlansService.getAllPlans()
        .then(response => {
            this.$store.commit("POPULATE_CROP_PLANS", response.data);
        })
        .catch(error => {
            console.error(error);
            alert("Error - see console.");
            });
        HarvestDataService.getAllHarvests()
        .then(response => {
            this.$store.commit("POPULATE_HARVEST_DATA", response.data);
        })
        .catch(error => {
            console.error(error);
            //alert("Error - see console.");
            });
        SaleDataService.getAllSales()
        .then(response => {
            this.$store.commit("POPULATE_SALE_DATA", response.data);
        })
        .catch(error => {
            console.error(error);
            //alert("Error - see console.");
            });
        LossDataService.getAllLosses()
        .then(response => {
            this.$store.commit("POPULATE_LOSS_DATA", response.data);
        })
        .catch(error => {
            console.error(error);
            //alert("Error - see console.");
            });
        WasteDataService.getAllWastes()
        .then(response => {
            this.$store.commit("POPULATE_WASTE_DATA", response.data);
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