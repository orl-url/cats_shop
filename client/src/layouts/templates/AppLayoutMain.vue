<template>
    <div class="app-layout">
        <AppLayoutMainHeader/>
        <div class="content">
            <slot/>
        </div>
    </div>
</template>

<script setup>
import AppLayoutMainHeader from "@/layouts/headers/AppLayoutMainHeader.vue";
</script>

<style scoped>
.app-layout {
    display: flex;
    flex-direction: column;
    //height: 100vh;
}

.content {
    flex-grow: 1;
}
</style>