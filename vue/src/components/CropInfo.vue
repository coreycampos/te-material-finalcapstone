<template>
    <div>
        <table>
            <tr>
                <td>
                    Harvest Time
                </td>
                <td>
                    Transplant Time
                </td>
            </tr>
          <tr>
              <td>
                  {{crop.harvestTime}}
              </td>
              <td>
                  {{crop.transplantTime}}
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