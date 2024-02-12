<script setup>
import CheckBoldIcon from "vue-material-design-icons/CheckBold.vue";
import ButtonAddToCart from "@/components/buttons/ButtonAddToCart.vue";
import CloseThickIcon from "vue-material-design-icons/CloseThick.vue";
import {useUserStore} from "@/stores/UserStore.js";

const userStore = useUserStore();

const props = defineProps({
  card: Object,
  showModal: Boolean
})


function getImgSrc(id) {
  return new URL(`../assets/images/${id}.jpg`, import.meta.url).href
}

</script>


<template>
  <Transition>
    <div v-if="props.showModal"
         class="modal_wrapper"
         @click.self="$emit('close')"
         @keydown.esc="$emit('close')"
    >
      <div
          class="big_card"
      >
        <button
            class="big_image_button"
        >
          <img :src="getImgSrc(props.card.imageId)" alt="bigImage"
               class="big_animalImg"
          />
        </button>


        <section class="big_bottom_part">
          <ul v-if="props.card"
              class="big_description"
          >
            <li v-for="(value, name) in props.card.characteristics">
              {{ name }}: {{ value }}
            </li>

          </ul>

          <div class="big_cost">

            <img class="big_coin_icon"
                 src="@/assets/images/coinIcon.svg"
                 alt="coin icon"
            >
            <p><span>{{ props.card.price }}</span></p>

            <button-add-to-cart
                class="add_to_cart_btn"
                :user-id="userStore.user.id"
                :card-id="props.card.id"
            />

          </div>

        </section>

      </div>
    </div>


  </Transition>
</template>

<style scoped>
.modal_wrapper {
  position: fixed;
  display: flex;
  align-items: center;
  justify-content: center;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  z-index: 900;


}


.big_card {
  position: relative;
  width: 80vw;
  min-width: 260px;
  max-width: 1000px;
  min-height: 340px;


  border: 2px red solid;
  border-radius: var(--default-border-radius);
  background-color: #f5f5f5;
}


.big_image_button,
.big_animalImg {
  border-radius: var(--default-border-radius) var(--default-border-radius) 0 0;
  aspect-ratio: 3/2;

  width: 100%;

  scale: none;
}

.big_bottom_part {
  width: auto;

  display: flex;
  justify-content: space-between;

  padding: 1rem 3rem;
  margin-bottom: 5rem;
}

.big_description {
  width: 70%;
}

.big_description li {
  padding-bottom: 0.8rem;
  display: flex;
  justify-content: flex-start;
  justify-items: flex-start;
  text-align: center;
  margin: auto 0;
  font-size: 3rem;
  padding-top: 1rem;

}


.big_cost {
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: end;
}

.big_coin_icon {
  height: 10rem;
  width: 10rem;
}


.md-icon {
  height: 4rem;
  width: 4rem;
}

.md-icon > .material-design-icon__svg {
  height: 2rem;
  width: 2rem;
}

.add_to_cart_btn {
  transform-origin: center top;
  scale: 2;
  margin-top: 5px;
}


.v-enter-active,
.v-leave-active {
  transition: all 300ms ease-out;
}

.v-enter-from {
  scale: 0.2;
}


.v-leave-to {
  transition: opacity 100ms ease-out;

  opacity: 0;
}



</style>