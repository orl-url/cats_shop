<script setup>
import {useCartStore} from "@/stores/CartStore.js";
import shoppingService from "@/services/shopping-service.js";
import {computed, onMounted, ref, watch} from "vue";
import cartService from "@/services/cart-service.js";
import {useUserStore} from "@/stores/UserStore.js";
import CardModal from "@/components/CardModal.vue";

const cartStore = useCartStore();
const userStore = useUserStore();


onMounted(async () => {
  if (userStore.user.id) {
    await getUserCart()
  }
})

watch(userStore.user, async () => {
  await getUserCart()
})

async function getUserCart() {
  cartStore.userCart.content = await cartService.getCartByUserIdAsync(userStore.user.id);
}

function removeFromCart(card) {
  cartService.removeFromCartAsync(userStore.user.id, card.id);
}

async function buyAll() {
  const responseData = await shoppingService.buyAllCartItems(userStore.user.id);
}

function clearCartContent() {
  cartService.clearCartAsync(userStore.user.id);
}

function getImgSrc(id) {
  return new URL(`../assets/images/${id}.jpg`, import.meta.url).href
}

const showModal = ref(false)
const modalEntity = ref()

function showCardModal(card) {
  modalEntity.value = card;
  showModal.value = true
}

function hideCardModal() {
  showModal.value = false
  modalEntity.value = null;

}


</script>


<template>
  <template
      v-if="cartStore.isCartShowed">

    <div class="cart_wrapper">


      <section
          class="zero_items_in_cart"
          v-if="cartStore.userCart.content <= 0"
      >
          <span>
            Nothing has been added to the cart yet.
          </span>
        <span>
            It's time to start!
          </span>

      </section>


      <section
          v-else
      >

        <ul class="cart_items">
          <li
              v-for="(card, index) in cartStore.userCart.content"
              :key="index"
              class="cart_item">

            <button @click="showCardModal(card)" class="img_button">
              <img :src="getImgSrc(card.imageId)" alt="cartImg" class="card_img">
            </button>


            <p class="characteristics">
              Age - {{ card.characteristics.age }},
              thoroughbred - {{ card.characteristics.thoroughbred }},
              vaccinated - {{ card.characteristics.vaccinated }},
              exhibitions participant - {{ card.characteristics.exhibitionsParticipant }}
            </p>


            <button
                @click="removeFromCart(card)">
              remove
            </button>


          </li>
        </ul>

        <div class="actionButtons">
          <div class="buyNow">

            <p class="sum">Sum: {{ cartStore.purchasesSum }}</p>

            <button
                @click="buyAll">
              Buy all
            </button>
          </div>


          <div class="clearCart">
            <button
                @click="clearCartContent">
              Remove all
            </button>

            <router-link to="/cart">Open the cart</router-link>
          </div>
        </div>
      </section>
    </div>
  </template>

  <card-modal
      :card="modalEntity"
      :show-modal="showModal"
      @close="hideCardModal"
  />

</template>

<style scoped>
.cart_wrapper {
  position: absolute;

  display: flex;
  flex-direction: column;

  //max-width: 35%;
  width: min-content;
  //min-width: 200px;
  //max-width: 600%;

  height: auto;
  max-height: 800px;


  top: 70px;
  right: 30px;

  background-color: #eeeeee;
  border: red solid 1px;
  border-radius: 20px;

  padding: 20px 20px 0 20px;

}

.zero_items_in_cart {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;

  margin-bottom: 20px;
  gap: 15px;

}

.cart_items {
  display: flex;
  flex-direction: column;

  position: relative;

  max-height: 600px;

  gap: 15px;

  overflow: scroll;
  scroll-behavior: smooth;
  margin-bottom: 10px;
}


.cart_item {
  display: flex;
  flex-direction: row;

  position: relative;

  gap: 15px;

  border: red 1px solid;

  padding-right: 10px;
  border-radius: var(--default-border-radius);

}

.characteristics {
  display: flex;
  margin: auto;

}

.img_button {
  max-width: 30%;
  border-radius: var(--default-border-radius);

  scale: none;
}


.card_img {
  width: 100%;
  height: 100%;
  aspect-ratio: 3/2;
  border-radius: var(--default-border-radius);
}

.actionButtons {
  position: relative;

  display: flex;
  flex-direction: column;

  align-content: space-between;
  margin: auto;

  width: 100%;
  min-height: 60px;

  padding: 10px 0 5px 0;
  border-top: green 5px solid;
}

.buyNow {
  display: flex;
  width: 50%;

  margin: 0 auto;
  gap: 20px;
}


.clearCart {
  display: flex;
  justify-content: space-between;
  width: 95%;
  margin: 0 auto;
}


@media screen and (max-width: 1300px)  {
    .characteristics {
      display: none;
    }
}

</style>

