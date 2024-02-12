<script setup>

import {computed, onMounted, ref} from "vue";
import CarouselImage from "@/components/CarouselImage.vue";

const props = defineProps({
  cards: Array
})


const animationIsRunning = ref(true);

const carouselCards = ref([]);

const animationStatus = computed(() => {
  if (animationIsRunning.value) {
    return "";
  } else {
    return "stop_animation";
  }
})

function runOrStopAnimation() {
  animationIsRunning.value = !animationIsRunning.value;
}


onMounted(() => {
  carouselCards.value = props.cards.slice(0, 6);
})
</script>

<template>
  <div
      class="display_container"
  >
    <div
        class="rotating_container"
        :class="animationStatus"
    >
      <carousel-image v-for="card in carouselCards"
                      :key="card.id"
                      :card="card"
                      @run-or-stop-animation="runOrStopAnimation"/>
    </div>
  </div>
</template>


<style scoped>
.display_container {
  position: relative;
  width: 40vw;
  height: 40vw;
  max-width: 380px;
  max-height: 250px;
  perspective: 1000px;
  transform-origin: center;

  margin: 0 auto;
}

.rotating_container {
  position: absolute;
  width: 100%;
  height: 100%;
  transform-origin: center;
  transform-style: preserve-3d;
  transform: translateZ(-35vw) rotateY(0);

  animation: carousel 25s infinite cubic-bezier(0.77, 0, 0.175, 1) forwards;
}


.stop_animation {
  animation-play-state: paused;
}


.rotating_container > .image_container:nth-child(1) {
  transform: rotateY(0) translateZ(35vw);

}

.rotating_container > .image_container:nth-child(2) {
  transform: rotateY(60deg) translateZ(35vw);
}

.rotating_container > .image_container:nth-child(3) {
  transform: rotateY(120deg) translateZ(35vw);
}

.rotating_container > .image_container:nth-child(4) {
  transform: rotateY(180deg) translateZ(35vw);
}

.rotating_container > .image_container:nth-child(5) {
  transform: rotateY(240deg) translateZ(35vw);
}

.rotating_container > .image_container:nth-child(6) {
  transform: rotateY(300deg) translateZ(35vw);
}


@keyframes carousel {
  0%, 14.3% {
    transform: translateZ(-35vw) rotateY(0);

  }
  14.3%, 28.6% {
    transform: translateZ(-35vw) rotateY(-60deg);
  }
  28.6%, 42.9% {
    transform: translateZ(-35vw) rotateY(-120deg);
  }
  42.9%, 57.2% {
    transform: translateZ(-35vw) rotateY(-180deg);
  }
  57.2%, 71.5% {
    transform: translateZ(-35vw) rotateY(-240deg);
  }
  71.5%, 85.8% {
    transform: translateZ(-35vw) rotateY(-300deg);
  }
  85.8%, 100% {
    transform: translateZ(-35vw) rotateY(-360deg);
  }
}
</style>