<template>
    <div>
        <table>
            <tr class="headerRow">
                <td>Loss Id</td>
                <td>Inventory Id</td>
                <td>Date Lost</td>
                <td>Amount Lost</td>
                <td>Loss Description</td>
            </tr>
            <tr>
                <td>{{loss.lossId}}</td>
                <td>{{loss.inventoryId}}</td>
                <td>{{loss.dateLost}}</td>
                <td>{{loss.amountLost}}</td>
                <td>{{loss.lossDescription}}</td>
            </tr>
          </table>
    </div>
</template>

<script>
export default {
    name: 'LossInfo',
    props: ['loss']
}
</script>