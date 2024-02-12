import localStorageService from "@/services/localStorageService.js";
import {useUserStore} from "@/stores/UserStore.js";
import {useAuthStore} from "@/stores/AuthStore.js";

class UserService {

  async setUserParams(userCredential) {

    if (this.trySaveToLS(userCredential)) {
      this.setParams(userCredential)
    } else if (!!this.tryGetFromLS()) {
      userCredential = this.tryGetFromLS()
      this.setParams(userCredential)
    }
  }


  trySaveToLS(userCredential) {
    if (userCredential) {
      localStorageService.saveToLS("user", userCredential)
      return true;
    }
  }

  tryGetFromLS() {
    let userIsSavedInLS = !!localStorageService.getFromLS("user");
    if (userIsSavedInLS) {
      return localStorageService.getFromLS('user');
    }
  }

  setParams(userCredential) {
    if (userCredential) {
      const userStore = useUserStore();
      const authStore = useAuthStore();

      userStore.setUserParams(userCredential);
      authStore.userIsLoggedIn = true;
    }
  }

  //   if (userCredential) {
  //     localStorageService.saveToLS("user", userCredential)
  //   } else {
  //     let userIsSavedInLS = !!localStorageService.getFromLS("user");
  //     if (userIsSavedInLS) {
  //       let userInLS = localStorageService.getFromLS('user');
  //       userCredential = userInLS;
  //     }
  //   }
  //
  //   if (userCredential) {
  //     const userStore = useUserStore();
  //     const authStore = useAuthStore();
  //
  //     userStore.setUserParams(userCredential);
  //     authStore.userIsLoggedIn = true;
  //   }
  // }

}


export default new UserService();