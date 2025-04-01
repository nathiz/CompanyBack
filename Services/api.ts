import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5090/api',
});

export default api;