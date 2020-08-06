import axios from 'axios';

// const http = axios.create({
// baseURL: "https://localhost:44315",
    
// })

export default {

  uploadFile(type, formData) {
      return axios.put(`/upload/${type}`,
        formData, 
        {
          headers: {
              'content-type': 'application/json',
          }
      })
    // console.log(type);
    // console.log(payload);
    // return axios.post(`/upload/${type}`, payload);
  },
  updateCrop(crop) {
    return axios.put('/upload/cropUpdate', crop);
  },

}
