<template>
    <div>
    <h2>Add a Loss</h2>
    <form v-on:submit.prevent>
        <div>
            <label for="inventoryIdInput">InventoryId</label>
            <input type="number" id="inventoryIdInput" v-model.number="loss.inventoryId">

            <label for="dateLostInput">Date Lost</label>
            <input type="date" id="dateLostInput" v-model="loss.dateLost">

            <label for="amountLostInput">Amount Lost</label>
            <input type="number" id="amountLostInput" v-model.number="loss.amountLost">

            <label for="lossDescriptionInput">Loss Description</label>
            <input type="text" id="lossDescriptionInput" v-model="loss.lossDescription">

            <input type="submit" v-on:click.prevent="saveLoss()">
        </div>
    </form>
    </div>
</template>

<script>
import lossService from '../services/LossDataService.js';
export default {
        name: 'add-loss',

    created() {
        this.loss.lossId = this.$route.params.loss.lossId;
        this.loss.inventoryId = this.$route.params.loss.inventoryId;
        this.loss.dateLost = this.$route.params.loss.dateLost;
        this.loss.amountLost = this.$route.params.loss.amountLost;
        this.loss.lossDescription = this.$route.params.loss.lossDescription;
    },

    data() {
        return {
            loss: {
                lossId: 0,
                inventoryId: 0,
                dateLost: Date.now(),
                amountLost: 0,
                lossDescription: ""
            }
        }
    },

    methods: {
        saveLoss() {
            lossService.addLoss(this.loss)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            this.$router.push({name: 'Home'});
        }
    }
}
</script>

<style scoped>

</style>