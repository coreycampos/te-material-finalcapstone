import axios from 'axios';

export default {

    getAllPlans() {
        return axios.get('plan/allPlans');
    },
    
    updateCropPlans(cropPlan){
        return axios.put('plan/planUpdate', cropPlan);
    }
}