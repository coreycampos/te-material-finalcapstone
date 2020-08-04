import axios from 'axios';

export default {

  uploadFile(csvFile, type) {
      return axios.post(`/upload/${type}`, csvFile)
  }

}
