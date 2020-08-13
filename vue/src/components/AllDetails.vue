<template>
    <div>
        <table id="full crop table" class="table table-hover">
            <thead class="headerRow">
                <th>Crop Name</th>
                <th>Seed to Harvest Time (days)</th>
                <th>Seed to Transpant Time (days)</th>
                <th>Transplant to Harvest Time (days)</th>
                <th>Time to Expiration (days)</th>
            </thead>
            <tbody>
            <tr v-for="item in $store.state.crop" v-bind:key="item.cropId">
                <td>{{item.cropName}}</td>
                <td>{{item.timeSeedToHarvest}}</td>
                <td>{{item.timeSeedToTransplant}}</td>
                <td>{{item.timeTransplantToHarvest}}</td>
                <td>{{item.timeToExpiration}}</td>
            </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    
}
</script>

<style scoped>
.headerRow {
    font-weight: bold;
}
</style>