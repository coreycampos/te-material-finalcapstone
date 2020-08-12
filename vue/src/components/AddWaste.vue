<template>
    <div>
    <button v-on:click="changeDisplay">Add Waste</button>
    <form v-on:submit.prevent v-show="display">
        <form v-on:submit.prevent="saveWaste()">
            <label for="inventoryIdInput">InventoryId</label>
            <input type="number" id="inventoryIdInput" v-model.number="waste.inventoryId" required>

            <label for="dateWastedInput">Date Wasted</label>
            <input type="date" id="dateWastedInput" v-model="waste.dateWasted" required>

            <label for="amountWastedInput">Amount Wasted</label>
            <input type="number" id="amountWastedInput" v-model.number="waste.amountWasted" required>

            <label for="wasteDescriptionInput">Waste Description</label>
            <input type="text" id="wasteDescriptionInput" v-model="waste.wasteDescription" required>

            <input type="submit">
        </form>
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
            display: false
        }
    },

    methods: {
        saveWaste() {
            wasteService.addWaste(this.waste)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            this.$router.push({name: 'Home'});
        },
        changeDisplay() {
            this.display = !this.display;
            console.log(this.display);
            },
    }
}
</script>

<style scoped>
input{
    display: block;
}
</style>