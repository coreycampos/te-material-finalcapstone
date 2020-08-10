import axios from 'axios';

export default {

    addSale(sale) {
        return axios.post('/add/Sale', sale);
      },
}