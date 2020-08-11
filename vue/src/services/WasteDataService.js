import axios from 'axios';

export default {

    addWaste(sale) {
        return axios.post('/add/Waste', sale);
    },
    getAllWastes() {
        return axios.get('Waste/AllWaste');
    },
}