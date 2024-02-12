<template>
  <div>
    Are you sure you want to log out of your account?
    To log in again, you will need to enter your credentials.
  </div>

  <div style="display: flex; ">
    <div style="margin: auto; padding-top: 10px">
      <button
          style="background-color: red; color: white"
          @click="authService.signOut()"
      >
        Logout
      </button>
      <button
          style="background-color: green; color: white"
          @click="redirectToMainPage()"
      >
        Return to main page
      </button>
    </div>

  </div>
</template>

<style scoped>

</style>

<script setup>

import authService from "@/services/authService.js";
import {useRouter} from "vue-router";

const router = useRouter();
function redirectToMainPage() {
  router.push("/");
}
</script>