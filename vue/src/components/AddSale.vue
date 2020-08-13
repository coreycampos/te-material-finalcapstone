<template>
    <div>
        <form v-on:submit.prevent="saveSale()">
            <label for="inventoryIdDropDown">Inventory ID</label>
            <select name="inventoryIdDropDown" id="inventoryIdDropDown"
                    v-model="sale.inventoryId"
                    required>
                <option value="" selected disabled>Select Inventory ID</option>
                <option v-for="inventory in saleInventories" v-bind:key="inventory.inventoryId">{{ inventory.inventoryId }}</option>
            </select>  
            
            <label for="dateSoldInput">Date Sold</label>
            <input type="date" id="dateSoldInput" v-model="sale.dateSold" required>

            <label for="amountSoldInput">Amount Sold</label>
            <input type="number" id="amountSoldInput" v-model.number="sale.amountSold" required>

            <label for="revenueInput">Revenue</label>
            <input type="number" id="revenueInput" v-model.number="sale.revenue" required>

            <label for="methodOfSaleInput">Method of Sale</label>
            <input type="text" id="methodOfSaleInput" v-model="sale.methodOfSale" required>

            <input type="submit">
            
        </form>
    </div>
</template>

<script>
import saleService from '../services/SaleDataService.js';
export default {
    name: 'add-sale',

    

    data() {
        return {
            sale: {
                saleId: 0,
                inventoryId: 0,
                dateSold: Date.now(),
                amountSold: 0,
                revenue: 0.00,
                methodOfSale: ""
            },
            display: false,
            saleInventories: {

            },
        }
    },

    methods: {
        saveSale() {
            saleService.addSale(this.sale)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            this.$router.push({name: 'AllFarmInfo'});
        },
    },
    created() {
        this.saleInventories = this.$store.state.inventory;
    }
}
</script>

<style scoped>
input, select {
    display: block;
}
</style>