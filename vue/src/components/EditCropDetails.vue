<template>
    <div>
        <h1>
            {{crop.cropName}}
        </h1>
        <form>
            <label for="seedToHarvestInput">
                Seed to Harvest Time
            </label>
            <input type="number" id="seedToHarvestInput" v-model.number="crop.timeSeedToHarvest">

            <label for="seedToTransplantInput">
                Seed to Transplant Time
            </label>
            <input type="number" id="seedToTransplantInput" v-model.number="crop.timeSeedToTransplant">

            <label for="transplantToHarvest">
                Transplant to Harvest Time
            </label>
            <input type="number" id="transplantToHarvest" v-model.number="crop.timeTransplantToHarvest">

            <label for="timetoExpiration">
                Time to Expiration
            </label>
            <input type="number" id="timeToExpiration" v-model.number="crop.timeToExpiration">

            <input type="submit" v-on:click.prevent="saveChanges(crop)">
        </form>
    </div>
</template>

<script>
import UploadService from "../services/UploadService.js"

export default {
    name: 'EditCrop',


    created(){
        this.crop.cropId = this.$route.params.crop.cropId;
        this.crop.cropName = this.$route.params.crop.cropName;
        this.crop.timeSeedToHarvest = this.$route.params.crop.timeSeedToHarvest;
        this.crop.timeSeedToTransplant = this.$route.params.crop.timeSeedToTransplant;
        this.crop.timeToExpiration = this.$route.params.crop.timeToExpiration;
        this.crop.timeTransplantToHarvest = this.$route.params.crop.timeTransplantToHarvest;
    },

    data(){
        return {
            crop:{
                cropId: "",
                cropName: "",
                timeSeedToHarvest: 0,
                timeSeedToTransplant: 0,
                timeToExpiration: 0,
                timeTransplantToHarvest: 0,
            }
           
        }
    },

    methods: {
        saveChanges(crop){
            UploadService.updateCrop(crop).then( () => {
                this.$router.push({name: 'crops'});
            })
        }
    }
}
</script>

<style scoped>
input {
    display: block;
}
</style>