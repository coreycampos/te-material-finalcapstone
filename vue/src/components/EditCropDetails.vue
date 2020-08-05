<template>
    <div>
        <form>
            <label for="seedToHarvestInput">
                Seed to Harvest Time
            </label>
            <input type="text" id="seedToHarvestInput" v-model="timeToHarvest">
            <label for="seedToTransplantInput">
                Transplant Time
            </label>
            <input type="text" id="seedToTransplantInput" v-model="timeToTransplant">
        </form>
    </div>
</template>

<script>
export default {
    name: 'EditCrop',
    props: ['crop'],

    data(){
        return {
            timeToHarvest: this.crop.timeSeedToHarvest,
            timeToTransplant: this.crop.timeSeedToTransplant,
        }
    }
}
</script>

<style>

</style>