import {defineStore} from "pinia";
import {ref} from "vue";

export const useCardsStore = defineStore('cards', () => {
  const cards = ref({
    content: [],
  })

  const filteredCards = ref({
    content: [],
  })

  return {
  };
})