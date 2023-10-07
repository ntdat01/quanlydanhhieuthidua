<template>
  <div>
    <TheHeader></TheHeader>
    <TheMenu></TheMenu>
    <TheMain></TheMain>
  </div>
</template>

<script>
import TheHeader from "./components/layout/TheHeader.vue"
import TheMenu from "./components/layout/TheMenu.vue"
import TheMain from "./components/layout/TheMain.vue"
export default {
  name: "App",
  components: {
    TheHeader, TheMain, TheMenu
  },
  data() {
    return {
      number: 1
    }
  }
};
</script>

<style>
@import "./css/main.css";
</style>
