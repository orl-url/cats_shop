import apiService from "@/services/api-service.js";
import {useAuthStore} from "@/stores/AuthStore.js";

class LocalStorageService {

  saveToLS(key, value) {
    localStorage.setItem(key, JSON.stringify(value))
  }

  getFromLS(key) {
    return JSON.parse(localStorage.getItem(key));
  }

  removeFromLS(key) {
    localStorage.removeItem(key)
  }

  clearLS() {
    localStorage.clear()
  }



}

export default new LocalStorageService();
