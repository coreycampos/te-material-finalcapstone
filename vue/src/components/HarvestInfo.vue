<template>
<div>
    <h2> Harvests</h2>
    <table class="table table-hover">
        <thead class="headerRow">
            <th>Harvest Id</th>
            <th>Inventory Id</th>
            <th>Crop Name</th>
            <th>Area</th>
            <th>Harvest Weight (lbs)</th>
            <th>Harvest Date</th>
        </thead>
        <tbody>
        <tr v-for="harvest in harvests" v-bind:key="harvest.harvestId">
            <td>{{harvest.harvestId}}</td>
            <td>{{harvest.inventoryId}}</td>
            <td>{{harvest.cropName}}</td>
            <td>{{harvest.area}}</td>
            <td>{{harvest.weight}}</td>
            <td>{{toDateString(harvest.dateHarvested)}}</td>
        </tr>
        </tbody>
    </table>
</div>
</template>

<script>
export default {
    name: 'HarvestInfo',
    props: ['harvests'],
    methods: {
      toDateString(longDate) {
        let simpleDate = longDate.split('T')[0];
        return simpleDate;
      },
    },
}
</script>

<style scoped>
.headerRow {
    font-weight: bold;
}

td{
    width: 20%;
}

table{
    width: 100%;
}
</style>