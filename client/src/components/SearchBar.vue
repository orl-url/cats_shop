<template>
  <input type="text" placeholder="Search..." v-model="searchQuery">
</template>

<script setup>
import {computed, onMounted, ref, watch} from "vue";


const searchQuery= ref("");

const props = defineProps({
  cards: Object,
})

const emits = defineEmits(['filterCards'])

watch(searchQuery, () => {
    emits('filterCards', filteredCards.value)
})

const filteredCards = computed(() => {
  if (props.cards === undefined || null) {
    return;
  }

  if (searchQuery.value === "") {
    return props.cards;
  }

  let filteredCards = props.cards.filter(item => {
    return item.category.toLowerCase().indexOf(searchQuery.value.toLowerCase()) !== -1;
  })

  return filteredCards;
})


onMounted(() => {
})


</script>

<style scoped>



</style>