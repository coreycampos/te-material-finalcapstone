<template>
    <div>
        <h2>Crop Waste</h2>
        <table>
            <tr class="headerRow">
                <td>Waste Id</td>
                <td>Inventory Id</td>
                <td>Date Wasted</td>
                <td>Amount Wasted</td>
                <td>Waste Description</td>
            </tr>
            <tr v-for="waste in wastes" v-bind:key="waste.wasteId">
                <td>{{waste.wasteId}}</td>
                <td>{{waste.inventoryId}}</td>
                <td>{{toDateString(waste.dateWasted)}}</td>
                <td>{{waste.amountWasted}}</td>
                <td>{{waste.wasteDescription}}</td>
            </tr>
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
</style>