<template>
  <div>
    <h2> Current Inventory</h2>
    <table class="table table-hover">
        <thead class="headerRow">
            <th>Inventory Id</th>
            <th>Crop</th>
            <th>Amount</th>
            <th>Date Added</th>
        </thead>
        <tbody>
        <tr v-for="inventory in inventories" v-bind:key="inventory.inventoryId">
            <td>{{inventory.inventoryId}}</td>
            <td>{{inventory.cropName}}</td>
            <td>{{inventory.amount}}</td>
            <td>{{toDateString(inventory.dateAdded)}}</td>
        </tr>
        </tbody>
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