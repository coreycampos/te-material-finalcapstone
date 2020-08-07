<template>
    <div>
        <button id="displayToggle" v-on:click="changeDisplay">
                    Display Details
                </button>
        <table v-show="display">
            <tr class="headerRow">
                <td>
                    Seed to Harvest Time
                </td>
                <td>
                    Seed to Transplant Time
                </td>
                <td>
                    Transplant to Harvest Time
                </td>
                <td>
                    Time to Expiration
                </td>
            </tr>
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
    font-size: 75%;
}
.informationRow{
    font-size: 60%;
}
</style>