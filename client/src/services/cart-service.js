import apiService from "@/services/api-service.js";
import {useCartStore} from "@/stores/CartStore.js";
import {useUserStore} from "@/stores/UserStore.js";
import {useAuthStore} from "@/stores/AuthStore.js";

class CartService {

  constructor() {
      this.cartStore = useCartStore();
      this.userStore = useUserStore();
      this.authStore = useAuthStore();
  }

  async getCartByUserIdAsync(userId) {
    if (!this.authStore.userIsLoggedIn) return;

    const result = await apiService.get(`/userCart/${userId}`);

    if (result.isSuccess === true) {
      return result.data
    } else {
      console.error("Cant get cart.", result);
    }
  }


  async addToCartAsync(userId, cardId) {
    if (!this.authStore.userIsLoggedIn) return;

    const result = await apiService.put(`/userCart/${userId}/${cardId}`);
    if (result.isSuccess === true) {
      this.cartStore.addToCart(result.data);
      return result.data;
    } else {
      console.error("Cant add this to cart.", result);
      return false;
    }
  }


  async removeFromCartAsync(userId, cardId) {
    if (!this.authStore.userIsLoggedIn) return;

    const result = await apiService.delete(`/userCart/${userId}/${cardId}`);

    if (result.isSuccess === true) {
      this.cartStore.removeFromCart(result.data)
      return result.data;
    } else {
      console.error("Cant remove this from cart.", result);
    }
  }


  async clearCartAsync(userId) {
    if (!this.authStore.userIsLoggedIn) return;

    const result = await apiService.delete(`/userCart/${userId}`);

    if (result.isSuccess === true) {
      this.cartStore.clearCart();
      return result;
    } else {
      console.error("Cant clear the cart.", result);
    }
  }
}

export default new CartService();