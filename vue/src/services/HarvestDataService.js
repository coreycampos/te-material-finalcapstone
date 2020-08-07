import axios from 'axios';

export default {

    addHarvest(harvest) {
        return axios.post('/add/Harvest', harvest);
      },
}