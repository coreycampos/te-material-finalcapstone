<template>
    <div>
        <table id="full crop table">
            <tr>
                <td>
                    <h1>
                    Crop Name &nbsp;
                    </h1>
                </td>
                <td>
                    <h1>
                    Seed to Harvest Time &nbsp;
                    </h1>
                </td>
                <td>
                    <h1>
                    Seed to Transpant Time
                    </h1>
                </td>
                <td>
                    <h1>
                    Transplant to Harvest Time
                    </h1>
                </td>
                <td>
                    <h1>
                        Time to Expiration
                    </h1>
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