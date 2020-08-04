import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user)
  },

  uploadFile(csvFile, type) {
      return axios.post(`/upload/${type}`, csvFile)
  }

}
