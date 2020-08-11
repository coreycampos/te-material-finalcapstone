import axios from 'axios';

export default {

    addSale(sale) {
        return axios.post('/add/Sale', sale);
    },
    getAllSales() {
        return axios.get('Sales/allSales');
    },
}