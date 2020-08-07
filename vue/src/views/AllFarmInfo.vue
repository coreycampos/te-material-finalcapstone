<template>
    <div>
        <plan-info />
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

export default {
    components: {
        SalesInfo,
        PlanInfo,
        LossInfo,
        HarvestInfo,
        WasteInfo
    }    
}
</script>

<style scoped>

</style>