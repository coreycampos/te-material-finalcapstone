<template>
    <div class="home">
    <h1>Home</h1>

    <h2 v-for="item in $store.state.crop" v-bind:key="item.cropId">
        {{item.cropName}}
                <!-- <button id="displayToggle" v-on:click="changeDisplay">
                    Display Details
                </button> -->
                
                <button id="sendToEdit" v-on:click="sendToEdit(item)">
                    Edit
                </button>
          <Crop-Info v-bind:crop="item" />
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
            },

        sendToEdit(item) {
            this.$router.push({name: 'EditCrop', params:{crop: item} })
        },

        updateCrop(item){
            this.crop.push(item);
            }
        }
    };
</script>