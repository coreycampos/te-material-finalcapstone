<template>
    <div>
    <h2>Add a Sale</h2>
    <form v-on:submit.prevent>
        <div>
            <label for="inventoryIdInput">InventoryId</label>
            <input type="number" id="inventoryIdInput" v-model.number="sale.inventoryId">

            <label for="dateSoldInput">Date Sold</label>
            <input type="date" id="dateSoldInput" v-model="sale.dateSold">

            <label for="amountSoldInput">Amount Sold</label>
            <input type="number" id="amountSoldInput" v-model.number="sale.amountSold">

            <label for="revenueInput">Revenue</label>
            <input type="number" id="revenueInput" v-model.number="sale.revenue">

            <label for="methodOfSaleInput">Method of Sale</label>
            <input type="text" id="methodOfSaleInput" v-model="sale.methodOfSale">

            <input type="submit" v-on:click.prevent="saveSale()">
            
        </div>
    </form>
    </div>
</template>

<script>
import saleService from '../services/SaleDataService.js';
export default {
    name: 'add-sale',

    created() {
        this.sale.saleId = this.$route.params.sale.saleId;
        this.sale.inventoryId = this.$route.params.sale.inventoryId;
        this.sale.dateSold = this.$route.params.sale.dateSold;
        this.sale.amountSold = this.$route.params.sale.amountSold;
        this.sale.revenue = this.$route.params.sale.revenue;
        this.sale.methodOfSale = this.$route.params.sale.methodOfSale;
    },

    data() {
        return {
            sale: {
                saleId: 0,
                inventoryId: 0,
                dateSold: Date.now(),
                amountSold: 0,
                revenue: 0.00,
                methodOfSale: ""
            }
        }
    },

    methods: {
        saveSale() {
            saleService.addSale(this.sale)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            this.$router.push({name: 'Home'});
        }
    }
}
</script>

<style scoped>

</style>