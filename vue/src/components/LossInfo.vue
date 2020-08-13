<template>
    <div>
        <h2>Crop Loss</h2>
        <table class="table table-hover">
            <thead class="headerRow">
                <th>Loss Id</th>
                <th>Inventory Id</th>
                <th>Crop Name</th>
                <th>Date Lost</th>
                <th>Amount Lost (lbs)</th>
                <th>Loss Description</th>
            </thead>
            <tbody>
            <tr v-for="loss in losses" v-bind:key="loss.lossId">
                <td>{{loss.lossId}}</td>
                <td>{{loss.inventoryId}}</td>
                <td>{{loss.cropName}}</td>
                <td>{{toDateString(loss.dateLost)}}</td>
                <td>{{loss.amountLost}}</td>
                <td>{{loss.lossDescription}}</td>
            </tr>
            </tbody>
          </table>
    </div>
</template>

<script>
export default {
    name: 'LossInfo',
    props: ['losses'],
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