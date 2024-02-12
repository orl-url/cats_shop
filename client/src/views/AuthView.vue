<template>
  <div class="parent">
    <div class="child">
      <section
          v-if="!authStore.userIsLoggedIn"
          class="small_window">
        Sign in if you
        <router-link to="/auth/signIn">have an account</router-link>
        or create a new account
        <router-link to="/auth/signUp">here</router-link>
      </section>


      <router-view/>
    </div>
  </div>
</template>

<style scoped>

.small_window {
  padding-bottom: 20px;
}

.parent {
  height: 40vh;
  display: flex;
  align-items: center;
  border: 1px solid red;
  margin-top: 10%;

}

.child {
  border: 1px solid red;
  padding: 20px;
  margin: auto;
}
</style>

<script setup>

import {useAuthStore} from "@/stores/AuthStore.js";

const authStore = useAuthStore();

</script>