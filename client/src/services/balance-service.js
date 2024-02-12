import apiService from "@/services/api-service.js";
import {useAuthStore} from "@/stores/AuthStore.js";

class BalanceService {
  constructor() {
    this.authStore = useAuthStore();
  }

  async getBalanceAsync(userId) {
    if (!this.authStore.userIsLoggedIn) return;
    const result = await apiService.get(`/userBalance/${userId}`);

    if (result.isSuccess === true) {
      return result.data;
    } else {
      console.error("Cant get balance.", result);
    }
  }
}


export default new BalanceService();