<template>
    <div>
        <button v-on:click="sendToAddHarvest">Add a Harvest</button>
        <button v-on:click="sendToAddLoss">Add a Loss</button>
        <button v-on:click="sendToAddSale">Add a Sale</button>
        <button v-on:click="sendToAddWaste">Add Waste</button>
    </div>
</template>

<script>

export default {
    components: {
        },
    methods: {
        sendToAddHarvest(){
            this.$router.push({name: 'AddHarvest'});
        },
        sendToAddLoss(){
            this.$router.push({name: 'AddLoss'});
        },
        sendToAddSale(){
            this.$router.push({name: 'AddSale'});
        },
        sendToAddWaste(){
            this.$router.push({name: 'AddWaste'});
        }
    }
}
</script>

<style scoped>
div{
    display: grid;
    grid-template-columns: 25% 25% 25% 25%;
}
</style>