import apiService from "@/services/api-service.js";
import {useAuthStore} from "@/stores/AuthStore.js";

class PurchasesService {
  constructor() {
    this.authStore = useAuthStore();
  }
  async getPurchasesAsync(userId) {
    if (!this.authStore.userIsLoggedIn) return ;

    const result = await apiService.get(`/userPurchases/${userId}`);

    if (result.isSuccess === true) {
      return result.data;
    } else {
      console.error("Cant get purchases.", result);
      return [];
    }
  }


  async addToPurchasesAsync(userId, purchases) {
    if (!this.authStore.userIsLoggedIn) return ;

    let purchasesId = await this.transformToId(purchases);

    const result = await apiService.put(`/userPurchases/${userId}`, purchasesId);

    if (result.isSuccess === true) {
      return result.data;
    } else {
      console.error("Cant add this to purchases.", result);
    }
  }


  async transformToId(purchases) {
    let purchasesId = [];
    purchases.forEach(purchase => purchasesId.push(purchase.id))
    return purchasesId;
  }

}


export default new PurchasesService();