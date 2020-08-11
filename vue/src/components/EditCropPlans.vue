<template>
    <div>
        <h1>Crop Plan {{cropPlan.planId}}</h1>
        <form>
            <label for="cropName">Crop Name</label>
            <input type="text" v-model="cropPlan.crop" id="cropName">

            <label for="areaIdentifier">Area Identifier</label>
            <input type="text" v-model="cropPlan.area_identifier" id="areaIdentifier">
            
            <label for="plantingDate">Planting Date</label>
            <input type="text" v-model="cropPlan.planting_date" id="plantingDate">
            <input type="submit">
        </form>

    </div>
</template>

<script>
export default {
    created(){
        this.cropPlan.crop = this.$route.params.cropPlan.crop;
        this.cropPlan.cropId = this.$route.params.cropPlan.cropId;
        this.cropPlan.planId = this.$route.params.cropPlan.planId;
        this.cropPlan.area_identifier = this.$route.params.cropPlan.area_identifier;
        this.cropPlan.planting_date = this.$route.params.cropPlan.planting_date;
    },

    data(){
        return{
            cropPlan: {
                crop: "",
                cropId: 0,
                planId: 0,
                area_identifier: "",
                planting_date: 0,
            }
        }
    }
}
</script>

<style scoped>
input{
    display:block;
}
</style>