<script setup>
import {computed, onMounted, ref, watch} from 'vue'
import {useCartStore} from "@/stores/CartStore.js";
import cardsService from "@/services/cards-service.js";
import {useUserStore} from "@/stores/UserStore.js";
import SearchBar from "@/components/SearchBar.vue";
import ProductCard from "@/components/ProductCard.vue";
import ImagesCarousel from "@/components/Carousel.vue";

const cartStore = useCartStore();
const userStore = useUserStore();


const cards = ref({
  content: []
})
const filteredCards = ref({
  content: []
})


const userId = computed(() => {
  return userStore.user.id;
})


function filterCards(filteredCardsFromBar) {
  filteredCards.value.content = filteredCardsFromBar;
}


onMounted(async () => {
  cards.value.content = await cardsService.getCardsAsync();
  filteredCards.value.content = cards.value.content;
})


</script>



<template>
  <main>

    <section class="carousel_section">
      <h2>The best of us from last week!</h2>

      <div class="carousel" v-if="cards.content.length > 0">
        <images-carousel
        :cards="cards.content"/>
      </div>
    </section>

    <search-bar
        class="search_bar"
        :cards="cards.content"
        @filter-cards="filterCards"
    />

    <section>
      <product-card
          v-for="card in filteredCards.content"
          :card="card"
      />


    </section>
  </main>


</template>


<style scoped>



.carousel_section {
  display: flex;
  flex-direction: column;
}

.carousel {
  display: flex;
}

h2 {
  font-size: 3rem;
  margin: auto;
  margin-bottom: 20px;
  margin-top: 40px  ;

}

main {
  display: flex;
  flex-direction: column;

}

.search_bar {
  width: 30%;

  margin: 100px auto 4vh auto;
}

section {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  gap: 5rem 0;

  justify-content: center;

  width: 80%;
  min-width: 300px;

  margin: auto;
}

@media screen and (max-width: 1250px ) {
  section {
    width: 100vw;
  }
}

</style>
