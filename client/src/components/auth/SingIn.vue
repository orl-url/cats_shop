<template>
  <form>
    <input type="text" placeholder="name" v-model="user.name">
    <input type="text" placeholder="password" v-model="user.password">

    <button type="button" @click="signIn">Login</button>
  </form>
</template>

<style scoped>
form {
  display: flex;
  flex-direction: column;
}

input {
  margin-bottom: 10px ;
}
</style>

<script setup>
import {ref} from "vue";
import authService from "@/services/authService.js";


const user = ref({
  name: '',
  password: '',
})

async function signIn() {
  const response = await authService.signIn(user.value)

  user.value.password = "";
}


</script>