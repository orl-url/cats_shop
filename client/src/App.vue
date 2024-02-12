<template>
  <AppLayout>
    <RouterView/>
  </AppLayout>
</template>

<style scoped>


</style>

<script setup>
import AppLayout from "@/layouts/AppLayout.vue";
import userService from "@/services/userService.js";

userService.setUserParams();
</script>