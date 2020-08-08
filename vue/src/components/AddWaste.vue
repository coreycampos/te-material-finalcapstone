<template>
    <div>
    <h2>Add a Waste</h2>
    <form v-on:submit.prevent>
        <div>
            <label for="inventoryIdInput">InventoryId</label>
            <input type="number" id="inventoryIdInput" v-model.number="waste.inventoryId">

            <label for="dateWastedInput">Date Wasted</label>
            <input type="date" id="dateWastedInput" v-model="waste.dateWasted">

            <label for="amountWastedInput">Amount Wasted</label>
            <input type="number" id="amountWastedInput" v-model.number="waste.amountWasted">

            <label for="wasteDescriptionInput">Waste Description</label>
            <input type="text" id="wasteDescriptionInput" v-model="waste.wasteDescription">

            <input type="submit" v-on:click.prevent="saveWaste()">
        </div>
    </form>
    </div>
</template>

<script>
export default {
    name: 'add-waste',

    created() {
        this.waste.wasteId = this.$route.params.waste.wasteId;
        this.waste.inventoryId = this.$route.params.waste.inventoryId;
        this.waste.dateWasted = this.$route.params.waste.dateWasted;
        this.waste.amountWasted = this.$route.params.waste.amountWasted;
        this.waste.wasteDescription = this.$route.params.waste.wasteDescription;
    },

    data() {
        return {
            waste: {
                wasteId: 0,
                inventoryId: 0,
                dateWasted: Date.now(),
                amountWasted: 0,
                wasteDescription: ""
            }
        }
    }
}
</script>

<style scoped>

</style>