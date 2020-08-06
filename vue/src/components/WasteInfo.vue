<template>
    <div>
        <table>
            <tr class="headerRow">
                <td>Waste Id</td>
                <td>Inventory Id</td>
                <td>Date Wasted</td>
                <td>Amount Wasted</td>
                <td>Waste Description</td>
            </tr>
            <tr>
                <td>{{waste.wasteId}}</td>
                <td>{{waste.inventoryId}}</td>
                <td>{{waste.dateWasted}}</td>
                <td>{{waste.amountWasted}}</td>
                <td>{{waste.wasteDescription}}</td>
            </tr>
          </table>
    </div>
</template>

<script>
export default {
    name: 'WasteInfo',
    props: ['waste']
}
</script>