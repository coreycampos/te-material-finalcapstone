import axios from 'axios';

export default {
    getInventoryData() {
        return axios.get('Inventory/allInventory');
    },
  
  }