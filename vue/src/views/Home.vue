<template>
  <div class="home">
    <h1>Home</h1>

    <table id="crop table">
      <tbody>
        <tr v-for="item in $store.state.crop" v-bind:key="item.name">
          <td>
            {{item.name}}
          </td>
          <td>
                <div class="cropDropdown">
        <select v-model="selected">
            <option disabled value="">Details</option>
            <option v-for="option in options" v-bind:key="option.name"><router-link :to="{name: `${option.name}`}">{{option.name}}
                </router-link>
            </option>
        </select>
                </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "home",

  data() {
    return {
      options: [

        {name: "Seed-to-harvest"},
        {name: "Seed-to-transplant"},
        {name: "Transplant-to-harvest"},
        {name: "Expiration"}
            ]
    }
  }
};
</script>
