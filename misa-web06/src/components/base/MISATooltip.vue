<template>
    <div class="tooltip-bg-hover">
        <div class="tooltip-text">
            {{ this.textTooltip }}
        </div>
        <div class="sub"></div>
    </div>
</template>

<script>
export default {
    name: "MISATooltip",
    props: ["textTooltip"],
    components: {},
    data() {
        return {};
    },
};
</script>

<style>
@import "../../css/layout/tooltip.css";
</style>
