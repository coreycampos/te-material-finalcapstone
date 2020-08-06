<template>
    <div>
        <table>
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
          <tr>
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
    props: ['crop']
}
</script>