<template>
<div>
    <h2> Harvests</h2>
    <table>
        <tr class="headerRow">
            <td>Harvest Id</td>
            <td>Crop</td>
            <td>Area</td>
            <td>Harvest Date</td>
        </tr>
        <tr>
            <td>{{harvest.harvestId}}</td>
            <td>{{harvest.cropPlanted}}</td>
            <td>{{harvest.area}}</td>
            <td>{{harvest.harvestDate}}</td>
        </tr>
    </table>
</div>
</template>

<script>
export default {
    name: 'HarvestInfo',
    props: ['harvest']
}
</script>

<style scoped>

</style>