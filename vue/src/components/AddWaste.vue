<template>
    <div>
        <form v-on:submit.prevent="saveWaste()">
            <label for="inventoryIdDropDown">Inventory ID</label>
            <select name="inventoryIdDropDown" id="inventoryIdDropDown"
                    v-model="waste.inventoryId"
                    required>
                <option value="" selected disabled>Select Inventory ID</option>
                <option v-for="inventory in wasteInventories" v-bind:key="inventory.inventoryId">{{ inventory.inventoryId }}</option>
            </select>
            
            <label for="dateWastedInput">Date Wasted</label>
            <input type="date" id="dateWastedInput" v-model="waste.dateWasted" required>

            <label for="amountWastedInput">Amount Wasted</label>
            <input type="number" id="amountWastedInput" v-model.number="waste.amountWasted" required>

            <label for="wasteDescriptionInput">Waste Description</label>
            <input type="text" id="wasteDescriptionInput" v-model="waste.wasteDescription" required>

            <input type="submit">
        </form>
    </div>
</template>

<script>
import wasteService from '../services/WasteDataService.js';
export default {
    name: 'add-waste',



    data() {
        return {
            waste: {
                wasteId: 0,
                inventoryId: 0,
                dateWasted: Date.now(),
                amountWasted: 0,
                wasteDescription: ""
            },
            display: false,
            wasteInventories: {

            },
        }
    },

    methods: {
        saveWaste() {
            wasteService.addWaste(this.waste)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            this.$router.push({name: 'AllFarmInfo'});
        },
    },
    created() {
        this.wasteInventories = this.$store.state.inventory;
    }
}
</script>

<style scoped>
input, select{
    display: block;
}
</style>