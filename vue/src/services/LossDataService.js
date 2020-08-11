import axios from 'axios';

export default {

    addLoss(loss) {
        return axios.post('/Loss/newLoss', loss);
    },
    getAllLosses() {
        return axios.get('Loss/AllLoss');
    },
}