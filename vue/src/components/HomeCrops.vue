<template>
    <div class="home">

    <h2 v-for="item in $store.state.crop" v-bind:key="item.cropId">
        {{item.cropName}}
                <router-link id="SendToEdit" v-bind:to="{name: 'EditCrop', params: {crop: item}}">Edit</router-link>
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

        updateCrop(item){
            this.crop.push(item);
            }
        }
    };
</script>

<style scoped>
button{
    font-size: 25%;
}
#SendToEdit{
    font-size: 50%;
}
</style>