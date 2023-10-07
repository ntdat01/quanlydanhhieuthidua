<template>
    <div class="slidebar">
        <div class="nav" id="style-1">
            <router-link to="/dashboard" class="nav-item">
                <m-icon Type="dashboard"></m-icon>
                <div class="nav__text">Tổng quan</div>
            </router-link>
            <router-link to="/compete" class="nav-item">
                <m-icon Type="compete"></m-icon>
                <div class="nav__text">Thi đua</div>
                <m-icon Type="right"></m-icon>
            </router-link>
            <router-link to="/bonus" class="nav-item">
                <m-icon Type="bonus"></m-icon>
                <div class="nav__text">Khen thưởng</div>
                <m-icon Type="right"></m-icon>
            </router-link>
            <router-link to="/decision" class="nav-item">
                <m-icon Type="decision"></m-icon>
                <div class="nav__text">Quyết định</div>
                <m-icon Type="right"></m-icon>
            </router-link>
            <router-link to="/file" class="nav-item">
                <m-icon Type="file"></m-icon>
                <div class="nav__text">Hồ sơ</div>
                <m-icon Type="right"></m-icon>
            </router-link>
            <router-link to="/search" class="nav-item">
                <m-icon Type="search"></m-icon>
                <div class="nav__text">Tra cứu</div>
                <m-icon Type="right"></m-icon>
            </router-link>
            <router-link to="/report" class="nav-item">
                <m-icon Type="report"></m-icon>
                <div class="nav__text">Báo cáo</div>
            </router-link>
            <hr>
            <router-link to="/category" class="nav-item nav-item--active">
                <m-icon Type="category"></m-icon>
                <div class="nav__text">Danh mục</div>
                <m-icon Type="right"></m-icon>
            </router-link>
            <router-link to="/setting" class="nav-item">
                <m-icon Type="setting"></m-icon>
                <div class="nav__text">Thiết lập</div>
                <m-icon Type="right"></m-icon>
            </router-link>
            <hr>
            <router-link to="/instruct" class="nav-item">
                <m-icon Type="instruct"></m-icon>
                <div class="nav__text">Hướng dẫn</div>
                <m-icon Type="right"></m-icon>
            </router-link>
        </div>
        <div class="nav-action nav-item">
            <m-icon Type="collapse"></m-icon>
            <div class="nav__text">Thu gọn</div>
        </div>
    </div>
</template>
<script>

export default {
    name: 'TheMenu',

};
</script>
<style scoped>
@import "../../css/layout/menu.css";
</style>
