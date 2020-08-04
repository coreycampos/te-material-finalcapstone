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
                    Harvest Time &nbsp;
                    </h1>
                </td>
                <td>
                    <h1>
                    Transplant Time
                    </h1>
                </td>
            </tr>
            <tr v-for="item in $store.state.crop" v-bind:key="item.name">
                <td>{{item.name}}</td>
                <td>{{item.harvestTime}}</td>
                <td>{{item.transplantTime}}</td>
            </tr>
        </table>
    </div>
</template>

<script>
export default {
    
}
</script>