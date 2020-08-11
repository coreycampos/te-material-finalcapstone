import axios from 'axios';

export default {

    addHarvest(harvest) {
        return axios.post('/Harvest/newHarvest', harvest);
      },
    getAllHarvests() {
        return axios.get('Harvest/allHarvests');
    },
}