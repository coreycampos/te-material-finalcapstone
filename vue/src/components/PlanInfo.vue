<template>
<div>
    <h2>Crop Plans</h2>
    <table>
        <tr class="headerRow">
            <td>Plan Id</td>
            <td>Crop</td>
            <td>Area</td>
            <td>Planting Date</td>
            <td>Planned Harvest Date</td>
        </tr>
        <tr v-for="plan in plans" v-bind:key="plan.planId">
            <td>{{plan.planId}}</td>
            <td>{{plan.cropName}}</td>
            <td>{{plan.area_identifier}}</td>
            <td>{{plan.planting_date}}</td>
            <td>tbd</td>
        </tr>
    </table>
</div>
</template>

<script>
export default {
    name: 'PlanInfo',
    props: ['plans']
}
</script>

<style scoped>
.headerRow {
    font-weight: bold;
}
</style>