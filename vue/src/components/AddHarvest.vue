<template>
    <div>
    <h2> Add a Harvest </h2>
    <form v-on:submit.prevent>
        
        <div>
            <label for="cropIdInput">cropId</label>
            <input type="number" id="cropIdInput" v-model.number="harvest.cropId">

            <label for="areaInput">Area</label>
            <input type="text" id="areaInput" v-model.number="harvest.area">

            <label for="weightInput">Weight</label>
            <input type="number" id="weightInput" v-model.number="harvest.weight">

            <label for="dateInput">Date of Harvest</label>
            <input type="date" id="dateInput" v-model="harvest.dateHarvested">

            <input type="submit" v-on:click.prevent="saveHarvest()">
        </div>
    </form>
    </div>
</template>

<script>
import harvestService from '../services/HarvestDataService.js';
export default {
    name: 'add-harvest',
    created() {
        this.harvest.harvestId = this.$route.params.harvest.harvestId;
        this.harvest.cropId = this.$route.params.harvest.cropId;
        this.harvest.area = this.$route.params.harvest.area;
        this.harvest.weight = this.$route.params.harvest.weight;
        this.harvest.dateHarvested = this.$route.params.harvest.dateHarvested;
    },

    data() {
        return {
            harvest: {
                harvestId: 0,
                cropId: 0,
                area: "",
                weight: 0,
                dateHarvested: Date.now()

            }
        }
    },

    methods: {
        saveHarvest() {
            harvestService.addHarvest(this.harvest)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            this.$router.push({ name: 'Home'});
        }
    }
   
}
</script>

<style scoped>
input {
    display: block;
}
</style>