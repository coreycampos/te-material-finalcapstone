<template>
    <div>
        <h2>Crop Sales</h2>
        <table>
            <tr class="headerRow">
                <td>Sale Id</td>
                <td>Inventory Id</td>
                <td>Date Sold</td>
                <td>Amount Sold</td>
                <td>Revenue</td>
                <td>Method of Sale</td>
            </tr>
            <tr v-for="sale in sales" v-bind:key="sale.saleId">
                <td>{{sale.saleId}}</td>
                <td>{{sale.inventoryId}}</td>
                <td>{{sale.dateSold}}</td>
                <td>{{sale.amountSold}}</td>
                <td>{{sale.revenue}}</td>
                <td>{{sale.methodOfSale}}</td>
            </tr>
          </table>
    </div>
</template>

<script>
export default {
    name: 'SalesInfo',
    props: ['sales']
}
</script>

<style scoped>
.headerRow {
    font-weight: bold;
}

table{
    margin-bottom: 20px;
    border-bottom: 1px solid black;
    width: 100%
}

td{
    width: 16%;
    padding-bottom: 10px;
}
</style>