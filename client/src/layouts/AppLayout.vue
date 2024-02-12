<template>
  <component :is="layout">
    <slot/>
  </component>
</template>

<script setup>
import {useRoute} from "vue-router";
import {shallowRef, watch} from "vue";
import AppLayoutDefault from "@/layouts/templates/AppLayoutDefault.vue";

const route = useRoute();
const layout = shallowRef(null);

watch(() => route.meta,
    async meta => {
      try {
        if (!meta.layout) {
          layout.value = AppLayoutDefault;
          return;
        }
        const component = await import(`./templates/${meta.layout}.vue`);
        layout.value = component?.default || AppLayoutDefault;
      } catch (e) {
        console.log(e)
        layout.value = AppLayoutDefault;
      }
    }
);
</script>