import axios from 'axios';

export default {

    addSale(sale) {
        return axios.post('/Sales/newSale', sale);
    },
    getAllSales() {
        return axios.get('Sales/allSales');
    },
}