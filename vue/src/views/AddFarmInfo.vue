<template>
    <div>
        <add-harvest />
        <add-loss />
        <add-sale />
        <add-waste />
    </div>
</template>

<script>
import AddHarvest from "../components/AddHarvest.vue"
import AddLoss from "../components/AddLoss.vue"
import AddSale from "../components/AddSale.vue"
import AddWaste from "../components/AddWaste.vue"

export default {
    components: {
        AddHarvest,
        AddLoss,
        AddSale,
        AddWaste,
        }
}
</script>

<style scoped>

</style>