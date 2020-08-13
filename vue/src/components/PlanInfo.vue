<template>
<div>
    <h2>Crop Plans</h2>
    <table class="table table-hover">
        <tr class="headerRow">
            <td>Plan Id</td>
            <td>Crop Name</td>
            <td>Area</td>
            <td>Planting Date</td>
            <td>Make Edits</td>
        </tr>
        <tr v-for="plan in plans" v-bind:key="plan.planId">
            <td>{{plan.planId}}</td>
            <td>{{plan.crop}}</td>
            <td>{{plan.area_identifier}}</td>
            <td>{{toDateString(plan.planting_date)}}</td>
            <td>
                <router-link v-bind:to="{name: 'EditCropPlans', params: {cropPlan: plan}}">Edit</router-link>
            </td>

        </tr>
    </table>
</div>
</template>

<script>
export default {
    name: 'PlanInfo',
    props: ['plans'],
    methods: {
      toDateString(longDate) {
        let simpleDate = longDate.split(' ')[0];
        return simpleDate;
      },
    },
}
</script>

<style scoped>
.headerRow {
    font-weight: bold;
}

td{
    width: 20%;
    padding-bottom: 10px;
}

table{
    margin-bottom: 20px;
    width: 100%;
}
</style>