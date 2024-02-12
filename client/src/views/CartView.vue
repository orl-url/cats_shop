<template>
  <ul>
    <li
        v-for="(purchase, index) in cartStore.userCart.content"
        :key="index">
      {{ purchase.price }}
      {{ purchase.category }}

      <button
          @click="removeFromCart(purchase)">
        remove
      </button>
    </li>

    Sum: {{cartStore.purchasesSum}}

  </ul>

  <button
      @click="buyAll">
    Buy all
  </button>

  <button
      @click="clearCartContent">
    Remove all
  </button>
</template>

<script setup>
import {useCartStore} from "@/stores/CartStore.js";
import {useUserStore} from "@/stores/UserStore.js";

const cartStore = useCartStore();
const userStore = useUserStore();



function removeFromCart(purchase) {
  cartStore.removeFromCart(purchase);
}

function clearCartContent() {
  cartStore.clearCartContent();
}

function buyAll() {
  cartStore.buyAll();
}
</script>



<style scoped>

</style>

