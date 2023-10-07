<template>
    <div>
        gõ html ở đây
    </div>
    <input type="text" v-model="fullName" />
    <div>{{ fullName }}</div>
    <div>{{ prop2 }}</div>
</template>
<script>
export default {
    name: "MISADemo",
    props: ["prop1", "prop2"],
    data() {
        return {
            fullName: "Nguyễn Thành Đạt",
        }
    },
}
</script>
<style>
</style>
