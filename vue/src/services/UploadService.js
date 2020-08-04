import axios from 'axios';

// const http = axios.create({
//     baseURL: "https://localhost:44315",
    
// })

export default {

  uploadFile(csvFile, type) {
      return axios.post(`/upload/${type}`, csvFile, {
          headers: {
              'content-type': 'multipart/form-data',
              'accept': 'multipart/form-data'
          }
      })
  }

}
