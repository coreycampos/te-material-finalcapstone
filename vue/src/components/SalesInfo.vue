<template>
    <div>
        <h2>Crop Sales</h2>
        <table class="table table-hover">
            <thead class="headerRow">
                <th>Sale Id</th>
                <th>Inventory Id</th>
                <th>Crop Name</th>
                <th>Date Sold</th>
                <th>Amount Sold (lbs)</th>
                <th>Revenue ($)</th>
                <th>Method of Sale</th>
            </thead>
            <tbody>
            <tr v-for="sale in sales" v-bind:key="sale.saleId">
                <td>{{sale.saleId}}</td>
                <td>{{sale.inventoryId}}</td>
                <td>{{sale.cropName}}</td>
                <td>{{toDateString(sale.dateSold)}}</td>
                <td>{{sale.amountSold}}</td>
                <td>{{sale.revenue}}</td>
                <td>{{sale.methodOfSale}}</td>
            </tr>
            </tbody>
          </table>
    </div>
</template>

<script>
export default {
    name: 'SalesInfo',
    props: ['sales'],
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
    width: 100%
}

td{
    width: 16%;
}
</style>