<template>
<div>
    <h2> Crop Plans</h2>
    <table>
        <tr class="headerRow">
            <td>Plan Id</td>
            <td>Crop</td>
            <td>Area</td>
            <td>Planned Harvest Date</td>
        </tr>
        <tr>
            <td>{{plan.planId}}</td>
            <td>{{plan.cropPlanted}}</td>
            <td>{{plan.area}}</td>
            <td>{{plan.plannedHarvestDate}}</td>
        </tr>
    </table>
</div>
</template>

<script>
export default {
    name: 'PlanInfo',
    props: ['plan']
}
</script>

<style scoped>

</style>