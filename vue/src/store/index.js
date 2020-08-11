import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')

let currentUser = null;
if ((localStorage.getItem('user') && localStorage.getItem('user') != 'undefined')) {
  currentUser = JSON.parse(localStorage.getItem('user'));
}
 
if(currentToken && currentToken != 'undefined') {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {}, // If a user is an admin, their user.role will be 'admin'
    crop: [{
        cropId: 1,
        cropName: "corn",
        timeSeedToHarvest: 80,
        timeSeedToTransplant: 10,
        timeToExpiration: 70,
        timeTransplantToHarvest: 60,
      },
      {
        cropId: 2,
        cropName: "wheat",
        timeSeedToHarvest: 110,
        timeSeedToTransplant: 14,
        timeToExpiration: 90,
        timeTransplantToHarvest: 96,
      },
      {
        cropId: 3,
        cropName: "summer squash",
        timeSeedToHarvest: 65,
        timeSeedToTransplant: 21,
        timeToExpiration: 30,
        timeTransplantToHarvest: 44,
      }
    ],
    cropPlans: [
      {
        planId: 5,
        area_identifier: "raised bed 1",
        cropName: "garlic",
        cropId: 9,
        planting_date: "05/02/2020",
      }
    ],
    harvests: [
      {
        area: "raised bed 1",
        cropId: 9,
        cropName: "garlic",
        dateHarvested: "08/10/2020",
        harvestId: 1,
        weight: 50,
      }
    ]
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    POPULATE_CROP_DATA(state, data) {
      state.crop = data;
    },
    POPULATE_CROP_PLANS(state, data) {
      state.cropPlans = data;
    },
    POPULATE_HARVEST_DATA(state, data) {
      state.harvests = data;
    }
  }
})
