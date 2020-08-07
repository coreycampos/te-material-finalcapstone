<template>
    <div>
        <table id="full crop table">
            <tr class="headerRow">
                <td>
                    Crop Name &nbsp;
                </td>
                <td>
                    Seed to Harvest Time &nbsp;
                </td>
                <td>
                    Seed to Transpant Time
                </td>
                <td>
                    Transplant to Harvest Time
                </td>
                <td>
                        Time to Expiration
                </td>
            </tr>
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