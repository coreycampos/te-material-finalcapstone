import axios from 'axios';

export default {

    getAllPlans() {
        return axios.get('plan/allPlans');
    },
}