import axios from 'axios';

export default {
    getCropData() {
        return axios.get('cropData');
    },
  
  }