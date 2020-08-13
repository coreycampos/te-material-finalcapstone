<template>
    <div>
        <button id="displayToggle" v-on:click="changeDisplay">
                    Display Details
                </button>
        <table v-show="display" class="table table-hover">
            <thead class="headerRow">
                <th>Seed to Harvest Time</th>
                <th>Seed to Transplant Time</th>
                <th>Transplant to Harvest Time</th>
                <th>Time to Expiration</th>
            </thead>
            <tbody>
          <tr class="informationRow">
              <td>
                  {{crop.timeSeedToHarvest}}
              </td>
              <td>
                  {{crop.timeSeedToTransplant}}
              </td>
              <td>
                  {{crop.timeTransplantToHarvest}}
              </td>
              <td>
                  {{crop.timeToExpiration}}
              </td>
          </tr>
            </tbody>
          </table>
    </div>
</template>

<script>
export default {
    name: 'CropInfo',
    props: ['crop'],
    data(){
        return {
            display: false
        }
    },
    methods: {
        changeDisplay() {
            this.display = !this.display;
            console.log(this.display);
            },
    }
}
</script>

<style scoped>
.headerRow{
    font-size: 50%;
}
.informationRow{
    font-size: 50%;
}
#displayToggle{
    font-size: 50%;
}
</style>