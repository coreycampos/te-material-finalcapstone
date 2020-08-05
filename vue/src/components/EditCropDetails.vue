<template>
    <div>
        <h1>
            {{crop.cropName}}
        </h1>
        <form>
            <label for="seedToHarvestInput">
                Seed to Harvest Time
            </label>
            <input type="text" id="seedToHarvestInput" v-model="crop.timeSeedToHarvest">

            <label for="seedToTransplantInput">
                Seed to Transplant Time
            </label>
            <input type="text" id="seedToTransplantInput" v-model="crop.timeSeedToTransplant">

            <label for="transplantToHarvest">
                Transplant to Harvest Time
            </label>
            <input type="text" id="transplantToHarvest" v-model="crop.timeTransplantToHarvest">

            <label for="timetoExpiration">
                Time to Expiration
            </label>
            <input type="text" id="timeToExpiration" v-model="crop.timeToExpiration">
        </form>
    </div>
</template>

<script>
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
                timeSeedToHarvest: "",
                timeSeedToTransplant: "",
                timeToExpiration: "",
                timeTransplantToHarvest: "",
            }
           
        }
    }
}
</script>

<style>

</style>