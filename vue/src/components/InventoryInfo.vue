<template>
  <div>
    <h2> Current Inventory</h2>
    <table>
        <tr class="headerRow">
            <td>Inventory Id</td>
            <td>Crop</td>
            <td>Amount</td>
            <td>Date Added</td>
        </tr>
        <tr v-for="inventory in inventories" v-bind:key="inventory.inventoryId">
            <td>{{inventory.inventoryId}}</td>
            <td>{{inventory.cropName}}</td>
            <td>{{inventory.amount}}</td>
            <td>{{toDateString(inventory.dateAdded)}}</td>
        </tr>
    </table>
  </div>
</template>

<script>
export default {
    name: 'InventoryInfo',
    props: ['inventories'],
    methods: {
      toDateString(longDate) {
        let simpleDate = longDate.split('T')[0];
        return simpleDate;
      },
    },
}
</script>

<style>
td{
    width: 25%;
    padding-bottom: 10px;
}

table{
    margin-bottom: 20px;
    width: 100%;
}
</style>