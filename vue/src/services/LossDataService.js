import axios from 'axios';

export default {

    addLoss(loss) {
        return axios.post('/add/Loss', loss);
      },
}