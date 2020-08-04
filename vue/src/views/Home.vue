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
            <button>
              Details
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>
