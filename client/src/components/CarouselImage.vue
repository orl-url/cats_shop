<script setup>
import ButtonAddToCart from "@/components/buttons/ButtonAddToCart.vue";
import {useUserStore} from "@/stores/UserStore.js";
import CardModal from "@/components/CardModal.vue";

const userStore = useUserStore();

const props = defineProps({
  card: Object
})

const emits = defineEmits(["runOrStopAnimation"])

function runOrStopAnimation() {
  emits('runOrStopAnimation')
}

function getImgSrc(id) {
  return new URL(`../assets/images/${id}.jpg`, import.meta.url).href
}


</script>

<template>
    <div class="image_container black_bg">
      <button
          class="image_button black_bg"
          @click="runOrStopAnimation"
      >
        <img :src="getImgSrc(props.card.imageId)" alt="img">


      </button>

      <div class="image_submenu">
        <div class="submenu_left_side">
          <ButtonAddToCart/>
        </div>
        <div class="submenu_right_side">
          <ButtonAddToCart
              :card-id="props.card.id"
              :user-id="userStore.user.id"
          />
        </div>
      </div>
    </div>

</template>

<style scoped>
.image_container,
.image_container > .image_button,
.image_container > .image_button > img {
  position: absolute;
  width: 100%;
  height: 100%;
  max-width: 380px;
  max-height: 250px;
  border-radius: var(--default-border-radius);
  transform-origin: center;

  scale: none;

  z-index: 1;
}

.image_container {
  display: flex;
  flex-direction: column;

}

.black_bg,
img {
  background-color: black;
}

.image_container:hover .image_submenu {
  animation: jelly_menu_buttons_in 1s ease-out forwards;
}

.image_container .image_submenu {
  animation: jelly_menu_buttons_out 1s ease;
}

.image_submenu {
  position: relative;
  display: flex;
  flex-direction: row;

  min-width: calc(var(--default-button-width) * 2);
  width: 100%;
  margin: 0 auto;
  top: calc(100% - var(--default-button-height));
  z-index: 10;

  animation: jelly_menu_buttons_out 1s ease;

  opacity: 0;
}


.submenu_left_side,
.submenu_right_side {
  position: absolute;
  z-index: 10;
}

.submenu_right_side {
  right: 0;
}

.image_container img {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;

  box-shadow: 0 0 5px black;
  border: red 1px solid;
}


@keyframes jelly_menu_buttons_in {
  from {
    width: 100%;
  }
  30%, 40% {
    width: calc(var(--default-button-width) * 2);
    opacity: 85%
  }
  40%, 50% {
    width: calc(var(--default-button-width) * 2 + 20px);
    opacity: 100%
  }
  50%, 60% {
    width: calc(var(--default-button-width) * 2);
    opacity: 100%
  }
  60%, 70% {
    width: calc(var(--default-button-width) * 2 + 10px);
    opacity: 100%
  }
  70%, 80% {
    width: calc(var(--default-button-width) * 2);
    opacity: 100%
  }
  80%, 90% {
    width: calc(var(--default-button-width) * 2 + 5px);
    opacity: 100%
  }
  90%, to {
    width: calc(var(--default-button-width) * 2);
    opacity: 100%;
  }
}

@keyframes jelly_menu_buttons_out {
  from {
    width: calc(var(--default-button-width) * 2);
    opacity: 100%
  }
  50% {
    opacity: 0
  }
  to {
    width: 100%;
  }
}
</style>