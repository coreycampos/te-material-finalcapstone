import axios from 'axios';

export default {

    addLoss(loss) {
        return axios.post('/add/Loss', loss);
    },
    getAllLosses() {
        return axios.get('Loss/AllLoss');
    },
}