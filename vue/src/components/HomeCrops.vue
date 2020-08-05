<template>
    <div class="home">
    <h1>Home</h1>

    <h2 v-for="item in $store.state.crop" v-bind:key="item.name">
        {{item.name}}
                <button id="displayToggle" v-on:click="changeDisplay">
                    Display Details
                </button>
          <Crop-Info v-bind:crop="item" v-show="display" />
    </h2>
    
  </div>
</template>


<script>
import CropInfo from '../components/CropInfo'

export default {
  name: "home",

    components: {
        CropInfo
    },

    data(){
        return {
            display: false
        }
    },

    methods: {
        changeDisplay() {
            this.display = !this.display;
            console.log(this.display);
            }
    }

};
</script>