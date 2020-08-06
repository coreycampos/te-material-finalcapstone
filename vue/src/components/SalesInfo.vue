<template>
    <div>
        <table>
            <tr class="headerRow">
                <td>Sale Id</td>
                <td>Inventory Id</td>
                <td>Date Sold</td>
                <td>Amount Sold</td>
                <td>Revenue</td>
                <td>Method of Sale</td>
            </tr>
            <tr>
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
    props: ['sale']
}
</script>