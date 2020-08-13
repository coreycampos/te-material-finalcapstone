<template>
    <div>
        <h2>Crop Loss</h2>
        <table>
            <tr class="headerRow">
                <td>Loss Id</td>
                <td>Inventory Id</td>
                <td>Date Lost</td>
                <td>Amount Lost</td>
                <td>Loss Description</td>
            </tr>
            <tr v-for="loss in losses" v-bind:key="loss.lossId">
                <td>{{loss.lossId}}</td>
                <td>{{loss.inventoryId}}</td>
                <td>{{toDateString(loss.dateLost)}}</td>
                <td>{{loss.amountLost}}</td>
                <td>{{loss.lossDescription}}</td>
            </tr>
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
</style>