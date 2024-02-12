import {defineStore} from "pinia";
import {ref, watch} from "vue";
import {useRouter} from "vue-router";

export const useAuthStore = defineStore('auth', () => {
  const router = useRouter();
  const userIsLoggedIn = ref(false);

  watch(userIsLoggedIn, async () => await router.push('/'))
  
  return {
    userIsLoggedIn,
  };
})