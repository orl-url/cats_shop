<script setup>
import {computed, ref} from "vue";
import {useUserStore} from "@/stores/UserStore.js";
import ButtonAddToCart from "@/components/buttons/ButtonAddToCart.vue";
import CloseThickIcon from "vue-material-design-icons/CloseThick.vue";
import CheckBoldIcon from "vue-material-design-icons/CheckBold.vue";
import CardModal from "@/components/CardModal.vue";

const userStore = useUserStore();

const props = defineProps({
  card: Object,
})

const showModal = ref(false)


function showCardModal() {
  showModal.value = true
}

function hideCardModal() {
  showModal.value = false
}


const imgSrc = computed(() => {
  return new URL(`../assets/images/${props.card.imageId}.jpg`, import.meta.url).href
})


</script>

<template>
  <div
      class="card border_radius"
      @keydown.esc="hideCardModal"
  >
    <button
        class="image_button"
        @click="showCardModal"
    >
      <img :src="imgSrc" alt=""
           class="animalImg"
      />
    </button>


    <section class="bottom_part">
      <ul v-if="props.card"
          class="description"
      >
        <li>Animal: {{ props.card.characteristics.animal }}</li>
        <li>Age: {{ props.card.characteristics.age }}</li>
        <li>Owners: {{ props.card.characteristics.ownersBeforeThat }}</li>
        <li>Vaccinated:
          <check-bold-icon
              v-if="props.card.characteristics.vaccinated === true"
              fill-color="green"
              :size="null"
              class="md-icon"
          />
          <close-thick-icon
              v-else
              fill-color="red"
              :size="null"
              class="md-icon"
          />
        </li>

        <li>Elite:
          <check-bold-icon
              v-if="props.card.characteristics.thoroughbred === true"
              fill-color="green"
              :size="null"
              class="md-icon"
          />
          <close-thick-icon
              v-else
              fill-color="red"
              :size="null"
              class="md-icon"
          />
        </li>
      </ul>

      <div class="cost">

        <img class="coin_icon"
             src="@/assets/images/coinIcon.svg"
             alt="coin icon"
        >
        <p><span>{{ props.card.price }}</span></p>

        <button-add-to-cart
            :user-id="userStore.user.id"
            :card-id="props.card.id"
        />

      </div>

    </section>

  </div>

  <card-modal
      :card="props.card"
      :show-modal="showModal"
      @close="hideCardModal"
  />

</template>

<style scoped>


.card {
  min-width: 175px;
  width: 200px;
  max-width: 20%;

  min-height: 150px;

  margin: 0 20px;
  border: red solid 1px;

  box-shadow: 0 0 10px black;
  background-color: white;

  border-radius: var(--default-border-radius);
}

.card > .image_button {
  border-radius: var(--default-border-radius) --default-border-radius 0 0;
  scale: none;
}


.animalImg {
  border-radius: var(--default-border-radius) var(--default-border-radius) 0 0;
  aspect-ratio: 3/2;

  width: 100%;
  min-width: 50px;
  max-width: 340px;

  max-height: 70%;

  margin: auto;
}

.coin_icon {
  height: 5rem;
  width: 5rem;
}


.md-icon {
  height: 2rem;
  width: 2rem;
}

.md-icon > .material-design-icon__svg {
  height: 2rem;
  width: 2rem;
}


ul {
  min-width: 70%;
}

ul li {

  padding-bottom: 0.8rem;
  display: flex;
  justify-content: flex-start;
  justify-items: flex-start;
  //text-align: center;

  margin: auto 0;

}


.bottom_part {
  display: flex;
  justify-content: space-between;
  padding: 0.5rem;
}

.description {
  min-width: 60%;
}

button {
  border-radius: 25px 25px 5px 5px;
}

.cost {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.cost p {
  text-align: center;
  font-size: 1.5rem;;
}


</style>
