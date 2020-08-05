<template>
    <div>
        <form>
            <label for="harvest time input">
                Harvest Time
            </label>
            <input type="text" id="harvest time input" v-model="harvestTime">
            <label for="transplant time input">
                Transplant Time
            </label>
            <input type="text" id="transplant time input" v-model="transplantTime">
        </form>
    </div>
</template>

<script>
export default {
    name: 'EditCrop',
    props: ['crop'],

    data(){
        return {
            harvestTime: this.crop.harvestTime,
            transplantTime: this.crop.transplantTime,
        }
    }
}
</script>

<style>

</style>