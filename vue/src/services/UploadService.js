import axios from 'axios';

// const http = axios.create({
// baseURL: "https://localhost:44315",
    
// })

export default {

  uploadFile(type, formData) {
      return axios.post(`/upload/${type}`,
        formData, 
        {
          headers: {
              'content-type': 'application/json',
          }
      })
    // console.log(type);
    // console.log(payload);
    // return axios.post(`/upload/${type}`, payload);
  }

}
