<template>
    <div class="search">
        <input class="input-search" type="text" name="" id="" :placeholder="Placeholder" :value="modelValue"
            autocomplete="off" />
        <m-icon Type="search icon-search" @click="handleSearch"></m-icon>
    </div>
</template>
<script>
export default {
    name: "MISASearch",
    props: ["Placeholder"],
}
</script>
<style scoped>
@import "../../css/layout/search.css";
</style>
