<template>
    <div>
        <table id="full crop table" class="table table-hover">
            <thead class="headerRow">
                <th scope="col">
                    Crop Name &nbsp;
                </th>
                <th scope="col">
                    Seed to Harvest Time &nbsp;
                </th>
                <th scope="col">
                    Seed to Transpant Time
                </th>
                <th scope="col">
                    Transplant to Harvest Time
                </th>
                <th scope="col">
                        Time to Expiration
                </th>
            </thead>
            <tr v-for="item in $store.state.crop" v-bind:key="item.cropId">
                <td>{{item.cropName}}</td>
                <td>{{item.timeSeedToHarvest}}</td>
                <td>{{item.timeSeedToTransplant}}</td>
                <td>{{item.timeTransplantToHarvest}}</td>
                <td>{{item.timeToExpiration}}</td>
            </tr>
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