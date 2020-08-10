<template>
    <div>
        <plan-info v-bind:plans="$store.state.cropPlans" />
        <harvest-info />
        <sales-info />
        <loss-info />
        <waste-info />
    </div>
</template>

<script>
import SalesInfo from "../components/SalesInfo.vue"
import PlanInfo from "../components/PlanInfo.vue"
import LossInfo from "../components/LossInfo.vue"
import HarvestInfo from "../components/HarvestInfo.vue"
import WasteInfo from "../components/WasteInfo.vue"
import CropPlansService from "../services/CropPlansService.js"

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
        }
}
</script>

<style scoped>

</style>