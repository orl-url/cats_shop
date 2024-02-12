<template >
  <div class="purchases">
    <div v-for="purchase in purchases">
      <card :card="purchase"/>
    </div>
  </div>



</template>

<style scoped>
.purchases {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;

}

.purchases div {
  margin: 0 15px 30px 0;
}
</style>

<script setup>
import {onMounted, ref, watch} from "vue";
import Card from "@/components/ProductCard.vue";
import purchasesService from "@/services/purchases-service.js";
import {useUserStore} from "@/stores/UserStore.js";

const purchases = ref([]);
const userStore= useUserStore();

onMounted(async () => {
    purchases.value = await purchasesService.getPurchasesAsync(userStore.user.id);
})

</script>