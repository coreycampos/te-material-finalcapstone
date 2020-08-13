<template>
    <div>
        <h2>Crop Waste</h2>
        <table class="table table-hover">
            <thead class="headerRow">
                <th>Waste Id</th>
                <th>Inventory Id</th>
                <th>Crop Name</th>
                <th>Date Wasted</th>
                <th>Amount Wasted (lbs)</th>
                <th>Waste Description</th>
            </thead>
            <tbody>
            <tr v-for="waste in wastes" v-bind:key="waste.wasteId">
                <td>{{waste.wasteId}}</td>
                <td>{{waste.inventoryId}}</td>
                <td>{{waste.cropName}}</td>
                <td>{{toDateString(waste.dateWasted)}}</td>
                <td>{{waste.amountWasted}}</td>
                <td>{{waste.wasteDescription}}</td>
            </tr>
            </tbody>
          </table>
    </div>
</template>

<script>
export default {
    name: 'WasteInfo',
    props: ['wastes'],
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

table{
    width: 100%;
}

td{
    width: 20%;
}
</style>