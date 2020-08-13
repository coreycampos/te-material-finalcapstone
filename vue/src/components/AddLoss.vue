<template>
    <div>
        <form v-on:submit.prevent="saveLoss()">
            <label for="inventoryIdDropDown">Inventory ID</label>
            <select name="inventoryIdDropDown" id="inventoryIdDropDown"
                    v-model="loss.inventoryId"
                    required>
                <option value="" selected disabled>Select Inventory ID</option>
                <option v-for="inventory in lossInventories" v-bind:key="inventory.inventoryId">{{ inventory.inventoryId }}</option>
            </select>  

            <label for="dateLostInput">Date Lost</label>
            <input type="date" id="dateLostInput" v-model="loss.dateLost" required>

            <label for="amountLostInput">Amount Lost</label>
            <input type="number" id="amountLostInput" v-model.number="loss.amountLost" required>

            <label for="lossDescriptionInput">Loss Description</label>
            <input type="text" id="lossDescriptionInput" v-model="loss.lossDescription" required>

            <input type="submit">
        </form>
    </div>
</template>

<script>
import lossService from '../services/LossDataService.js';
export default {
        name: 'add-loss',

    data() {
        return {
            loss: {
                lossId: 0,
                inventoryId: 0,
                dateLost: Date.now(),
                amountLost: 0,
                lossDescription: ""
            },

            display: false,

            lossInventories: {

            },
        }
    },

    methods: {
        saveLoss() {
            lossService.addLoss(this.loss)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            this.$router.push({name: 'AllFarmInfo'});
        },
    },
    created() {
        this.lossInventories = this.$store.state.inventory;
    }
}
</script>

<style scoped>
input, select{
    display: block;
}
</style>