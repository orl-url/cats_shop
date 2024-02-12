import balanceService from "@/services/balance-service.js";
import axios from "axios";
import apiService from "@/services/api-service.js";
import {useCartStore} from "@/stores/CartStore.js";
import {useUserStore} from "@/stores/UserStore.js";
import cartService from "@/services/cart-service.js";
import {useAuthStore} from "@/stores/AuthStore.js";

class ShoppingService {
  constructor() {
    this.cartStore = useCartStore();
    this.userStore = useUserStore();
    this.authStore = useAuthStore();
  }

  async buyAllCartItems(userId) {
    if (!this.authStore.userIsLoggedIn) return;

    const result = await apiService.post(`/buyAll/${userId}`);

    if (result.isSuccess === true) {
      this.userStore.setBalanceValue(result.data);
      await cartService.clearCartAsync(userId)
      return result.data;
    } else {
      console.error("Cant buy it.", result);
    }
  }
}


export default new ShoppingService();