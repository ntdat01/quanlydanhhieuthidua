<template>
    <div :class="['icon', 'icon--' + Type]"></div>
</template>
<script>
export default {
    name: "MISAIcon",
    props: ["Type"]
}
</script>
<style>
@import "../../css/layout/icon.css";
</style>
