<template>
    <div>
        <h1>Crop Plan {{cropPlan.planId}}</h1>
        <form>
            <label for="cropNameDropDown">Crop Name</label>
            <select name="cropNameDropDown" id="cropNameDropDown" 
                    v-model="cropPlan.crop"
                    required>
                <option value="" selected disabled>Select Crop Name</option>
                <option v-for="crop in crops" v-bind:key="crop.cropName">{{ crop.cropName }}</option>
            </select>

            <label for="areaIdentifier">Area Identifier</label>
            <input type="text" v-model="cropPlan.area_identifier" id="areaIdentifier">
            
            <label for="plantingDate">Planting Date</label>
            <input type="text" v-model="cropPlan.planting_date" id="plantingDate">
            
            <input type="submit" v-on:click.prevent="saveChanges(cropPlan)">
        </form>

    </div>
</template>

<script>
import CropPlansService from "../services/CropPlansService.js"

export default {
    created(){
        this.cropPlan.crop = this.$route.params.cropPlan.crop;
        this.cropPlan.cropId = this.$route.params.cropPlan.cropId;
        this.cropPlan.planId = this.$route.params.cropPlan.planId;
        this.cropPlan.area_identifier = this.$route.params.cropPlan.area_identifier;
        this.cropPlan.planting_date = this.$route.params.cropPlan.planting_date;

        this.crops = this.$store.state.crop;
    },

    data(){
        return{
            cropPlan: {
                crop: "",
                cropId: 0,
                planId: 0,
                area_identifier: "",
                planting_date: 0,
            },
            crops: {

            }
        }
    },

    methods: {
        saveChanges(cropPlan){
            CropPlansService.updateCropPlans(cropPlan).then( () => {
                this.$router.push({name: 'AllFarmInfo'});
            })
        }
        
    },
}
</script>

<style scoped>
input, select{
    display:block;
}
</style>