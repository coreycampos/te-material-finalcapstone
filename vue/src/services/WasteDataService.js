import axios from 'axios';

export default {

    addWaste(sale) {
        return axios.post('/add/Waste', sale);
      },
}