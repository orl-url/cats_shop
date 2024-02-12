<script setup>
import {computed, ref, watch} from "vue";
import cartService from "@/services/cart-service.js";

const TIME_FOR_REVERSE_TURN = 700;

const buttonPressed = ref(false)
const requestIsSuccessful = ref()

const props = defineProps({
  userId: String,
  cardId: String,
})


const btn_12 = computed(() => {
  if (buttonPressed.value) {

    return requestIsSuccessful.value === true
        ? "custom-btn-pressed-successful"
        : "custom-btn-pressed-denied custom-btn-pressed"
  } else {
    return "";
  }
})

async function addToCart() {
  const response = await cartService.addToCartAsync(props.userId, props.cardId)
  if (response) {
    requestIsSuccessful.value = true;
  } else if (response === false) {
    requestIsSuccessful.value = false;
  }
}

watch(requestIsSuccessful, () => {
  if (requestIsSuccessful.value !== null) {
    buttonPressed.value = true;

    setTimeout(() => {
      buttonPressed.value = false
      requestIsSuccessful.value = null
    }, TIME_FOR_REVERSE_TURN)
  }
})

</script>


<template>
  <button
      :class=btn_12
      class="btn-add-to-cart"
      @click="addToCart"
      :disabled="buttonPressed"
  >
    <span>to cart</span>
    <span>added</span>
    <span>cant</span>
  </button>
</template>


<style scoped>
.btn-add-to-cart {
  display: inline-block;
  position: relative;

  width: var(--default-button-width);
  height: var(--default-button-height);
  min-height: 20px;

  color: #fff;
  border-radius: 5px;
  background: transparent;
  cursor: pointer;
  outline: none;
  border: none;
  box-shadow: none;

  font-weight: 500;
  line-height: 4rem;

  transition: all 0.3s ease;
  perspective: none;

  z-index: 10;

  top: 5px;
}

.btn-add-to-cart:hover {
  transform: scale(1.03);
  color: #000000;
}

.custom-btn-pressed {
  animation: jelly 0.6s ease;
}


.btn-add-to-cart span {
  display: block;
  position: absolute;
  width: var(--default-button-width);
  height: var(--default-button-height);
  min-height: 20px;

  border-radius: 5px;
  margin: 0;
  bottom: 3px;

  text-align: center;
  box-sizing: border-box;

  transition: all 350ms;

  background: rgb(144, 159, 162);
  background: linear-gradient(0deg, rgba(0, 172, 238, 1) 0%, rgba(2, 126, 251, 1) 100%);

  box-shadow: inset 2px 2px 2px 0 rgba(255, 255, 255, .5),
  7px 7px 20px 0 rgba(0, 0, 0, .1),
  4px 4px 5px 0 rgba(0, 0, 0, .1);
}


.btn-add-to-cart span:nth-child(1) {
  transform-origin: 50% 50% -2rem;
  transform: rotateX(0deg);

}

.btn-add-to-cart span:nth-child(2) {
  transform-origin: 50% 50% -2rem;
  transform: rotateX(90deg);
  opacity: 0;

  box-shadow: -7px -7px 20px 0 #fff9,
  -4px -4px 5px 0 #fff9,
  7px 7px 20px 0 #0002,
  4px 4px 5px 0 #0001;

  background: linear-gradient(110.1deg, rgb(34, 126, 34) 2.9%, rgb(128, 204, 23) 90.3%);
  color: yellow;
}


.btn-add-to-cart span:nth-child(3) {
  opacity: 100%;
  transform-origin: 50% 50% -2rem;

  box-shadow: -7px -7px 20px 0 #fff9,
  -4px -4px 5px 0 #fff9,
  7px 7px 20px 0 #0002,
  4px 4px 5px 0 #0001;

  background: linear-gradient(110.1deg, rgb(199, 58, 73) 2.9%, rgb(176, 21, 35) 90.3%);
  color: #ffffff;
  transform: rotateX(-90deg);
}


.custom-btn-pressed-successful span:nth-child(1) {
  box-shadow: inset 2px 2px 2px 0 rgba(255, 255, 255, .5),
  7px 7px 20px 0 rgba(0, 0, 0, .1),
  4px 4px 5px 0 rgba(0, 0, 0, .1);
  color: transparent;

  opacity: 20%;

  transform: rotateX(-90deg);
}

.custom-btn-pressed-denied span:nth-child(1) {
  opacity: 60%;
  transform: rotateX(90deg);

  box-shadow: inset 2px 2px 2px 0 rgba(255, 255, 255, .5),
  7px 7px 20px 0 rgba(0, 0, 0, .1),
  4px 4px 5px 0 rgba(0, 0, 0, .1);
  color: transparent;
}


.custom-btn-pressed-successful span:nth-child(2) {
  transform: rotateX(0deg);
  opacity: 100%;
  box-shadow: inset 2px 2px 2px 0 rgba(255, 255, 255, .5),
  7px 7px 20px 0 rgba(0, 0, 0, .1),
  4px 4px 5px 0 rgba(0, 0, 0, .1);

  background: linear-gradient(110.1deg, rgb(34, 126, 34) 2.9%, rgb(128, 204, 23) 90.3%);
  color: yellow;
}

.custom-btn-pressed-denied span:nth-child(3) {
  transform: rotateX(0deg);
  opacity: 100%;

  box-shadow: inset 2px 2px 2px 0 rgba(255, 255, 255, .5),
  7px 7px 20px 0 rgba(0, 0, 0, .1),
  4px 4px 5px 0 rgba(0, 0, 0, .1);

  background: linear-gradient(110.1deg, rgb(199, 58, 73) 2.9%, rgb(176, 21, 35) 90.3%);
  color: #ffffff;
}


@keyframes jelly {
  from {
    transform: scale(1, 1);
  }
  30% {
    transform: scale(1.15, 0.90);
  }
  40% {
    transform: scale(0.90, 1.15);
  }
  50% {
    transform: scale(1.15, 0.90);
  }
  65% {
    transform: scale(0.90, 1.05);
  }
  75% {
    transform: scale(1.05, 0.95);
  }
  to {
    transform: scale(1, 1);
  }
}

</style>