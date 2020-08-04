import axios from 'axios';

const http = axios.create({
baseURL: "https://localhost:44315",
    
})

export default {

  uploadFile(csvFile, type) {
      return http.post(`/upload/${type}`, csvFile);
  }

}
