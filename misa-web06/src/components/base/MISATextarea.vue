<template>
  <div class="group-textarea">
    <label :for="Id">{{ LabelTitle }}</label>
    <textarea name="" :id="Id" cols="10" rows="4"></textarea>
  </div>
</template>

<script>
export default {
  name: "MISATextArea",
  props: ["Id", "LabelTitle", "Placeholder", "modelValue", "Disable"],
  emits: ["update:modelValue"],
  inheritAttrs: false,
};
</script>

<style scoped>
@import "../../css/layout/textarea.css";
</style>
