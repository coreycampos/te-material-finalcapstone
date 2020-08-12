<template>
    <div>
    <button v-on:click="changeDisplay">Add a Harvest</button>
    <form v-on:submit.prevent v-show="display">
        
        <div>
            <label for="cropNameInput">Crop Name</label>
            <input type="text" id="cropNameInput" v-model.number="harvest.cropName">

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

    data() {
        return {
            harvest: {
                harvestId: 0,
                cropName: "",
                area: "",
                weight: 0,
                dateHarvested: Date.now()
            },

            display: false
        }
    },

    methods: {
        saveHarvest() {
            harvestService.addHarvest(this.harvest)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            if (this.$router.name !== 'home') {
                console.log("Made it to line 56");
                this.$router.push({name: 'home'});
            }
        },
        changeDisplay() {
            this.display = !this.display;
            console.log(this.display);
            },
    }
   
}
</script>

<style scoped>
input {
    display: block;
}
</style>