import axios from 'axios';

export default {

    addWaste(waste) {
        return axios.post('/Waste/newWaste', waste);
    },
    getAllWastes() {
        return axios.get('Waste/AllWaste');
    },
}