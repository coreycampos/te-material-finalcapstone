<template>
    <div>
        <form v-on:submit.prevent="saveHarvest()">
            <label for="cropNameDropDown">Crop Name</label>
            <select name="cropNameDropDown" id="cropNameDropDown" 
                    v-model="harvest.cropName"
                    required>
                <option value="" selected disabled>Select Crop Name</option>
                <option v-for="crop in crops" v-bind:key="crop.cropName">{{ crop.cropName }}</option>
            </select>

            <label for="areaInput">Area</label>
            <input type="text" id="areaInput" v-model.number="harvest.area" required>

            <label for="weightInput">Weight</label>
            <input type="number" id="weightInput" v-model.number="harvest.weight" required>

            <label for="dateInput">Date of Harvest</label>
            <input type="date" id="dateInput" v-model="harvest.dateHarvested" required>

            <input type="submit">
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
            display: false,
            crops: {

            },
        }
    },
    methods: {
        saveHarvest() {
            harvestService.addHarvest(this.harvest)
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
            if (this.$router.name !== 'AllFarmInfo') {
                console.log("Made it to line 56");
                this.$router.push({name: 'AllFarmInfo'});
            }
        },
    },
    created() {
        this.crops = this.$store.state.crop;
    }
}
</script>

<style scoped>
input, select {
    display: block;
}
</style>