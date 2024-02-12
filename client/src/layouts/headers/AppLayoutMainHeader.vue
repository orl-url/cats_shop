<template>
  <header>
    <nav>
     <toggle-dark-mode/>

      <router-link to="/">Shop</router-link>
      <router-link to="/purchases">My purchases</router-link>
    </nav>


    <div class="right_side">
      <span v-if="balance">Cats coins: {{ balance }}</span>

      <button
          @click="toggleCartDisplay()">
        Cart
      </button>

      <Cart/>

      <router-link
          v-if="!authStore.userIsLoggedIn"
          to="/auth/signIn"
      >
        Login
      </router-link>

      <router-link
          v-if="authStore.userIsLoggedIn"
          to="/auth/signOut"
      >
        Logout
      </router-link>
    </div>
  </header>
</template>


<style scoped>


header {
  position: sticky;

  display: flex;
  flex-direction: row;
  justify-content: space-around;

  width: 100%;
  height: 6vh;

  top: 0;
  padding-left: 10px;
  padding-right: 10px;

  background-color: white;
  z-index: 500;
}

nav {
  display: flex;
  gap: 2vw;
}

a, span, button {
  font-size: 1.6rem;
  margin: auto;
  color: #3f3e3e

}



.right_side {
  display: flex;
  gap: 1rem;
  margin-right: 1rem;
}


</style>


<script setup>
import {computed, onMounted, watch} from "vue";
import {useCartStore} from "@/stores/CartStore.js";
import {useUserStore} from "@/stores/UserStore.js";
import Cart from "@/components/CartAsWindow.vue";
import balanceService from "@/services/balance-service.js";
import {useAuthStore} from "@/stores/AuthStore.js";
import ToggleDarkMode from "@/components/test/ToggleDarkMode.vue";


const cartStore = useCartStore();
const userStore = useUserStore();
const authStore = useAuthStore();


const balance = computed(() => {
  return userStore.user.balance ? userStore.user.balance : '0';
})

onMounted(async () => {
  if (userStore.user.id) {
    await getUserBalance()
  }
})

watch(userStore.user, async () => {
  await getUserBalance()
})

const imgSrc = computed(() => {
  return new URL(`../assets/images/coinIcon.jpg`, import.meta.url).href
})

async function getUserBalance() {
  userStore.user.balance = await balanceService.getBalanceAsync(userStore.user.id)
}


function toggleCartDisplay() {
  cartStore.toggleCartDisplay();
}


</script>
