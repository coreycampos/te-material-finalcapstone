<template>
<div>
    <h2> Harvests</h2>
    <table>
        <tr class="headerRow">
            <td>Harvest Id</td>
            <td>Crop</td>
            <td>Area</td>
            <td>Harvest Weight</td>
            <td>Harvest Date</td>
        </tr>
        <tr v-for="harvest in harvests" v-bind:key="harvest.harvestId">
            <td>{{harvest.harvestId}}</td>
            <td>{{harvest.cropName}}</td>
            <td>{{harvest.area}}</td>
            <td>{{harvest.weight}}</td>
            <td>{{harvest.dateHarvested}}</td>
        </tr>
    </table>
</div>
</template>

<script>
export default {
    name: 'HarvestInfo',
    props: ['harvests']
}
</script>

<style scoped>
.headerRow {
    font-weight: bold;
}
</style>