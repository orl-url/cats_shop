import apiService from "@/services/api-service.js";
import {useAuthStore} from "@/stores/AuthStore.js";
import localStorageService from "@/services/localStorageService.js";
import userService from "@/services/userService.js";
import {useUserStore} from "@/stores/UserStore.js";

class AuthService {

  constructor() {
    this.authStore = useAuthStore();
    this.userStore = useUserStore();

  }
  async signUp(credential) {
    const result = await apiService.post("/signUp", credential)

    if (result.isSuccess === true) {
      let user = result.data;
      await userService.setUserParams(user)

      return result.data;
    } else {
      console.error("Cant sign up.", result);
    }
  }


  async signIn(credential) {
    const result = await apiService.post("/signIn", credential)

    if (result.isSuccess === true) {
      let user = result.data;
      await userService.setUserParams(user)

      return result.data;
    } else {
      console.error("Cant sign in .", result);
    }
  }


  async signOut() {
    const result = await apiService.post("/signOut")

    localStorageService.removeFromLS("user")
    this.userStore.clearUserParams();
    this.authStore.userIsLoggedIn = false;
  }
}

export default new AuthService();
