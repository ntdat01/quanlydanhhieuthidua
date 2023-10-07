<template>
    <div class="header">
        <div class="header--left">
            <m-icon Type="toggle"></m-icon>
            <img class="logo" src="../../assets/imgs/logo.svg" alt="">
            <div class="logo--text">
                MISA CeGov
            </div>
        </div>
        <div class="header--right">
            <div class="icon icon--notification tooltip-notification">
                <span class="tooltip-text">Thông báo</span>
            </div>
            <m-icon Type="help"></m-icon>
            <m-icon Type="more"></m-icon>
            <m-icon Type="document"></m-icon>
            <m-icon Type="setting"></m-icon>
            <img class="avatar" src="../../assets/imgs/avatar.png" alt="">
        </div>
    </div>
</template>
<script>
export default {
    name: 'TheHeader',
};
</script>
<style scoped>
@import "../../css/layout/header.css";
</style>
