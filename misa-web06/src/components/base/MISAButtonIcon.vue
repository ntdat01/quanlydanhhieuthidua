<template>
    <div>
        <button :class="['btn', 'btn--' + Type]">
            <div :class="['icon', 'icon--' + Icon]"></div>
            <div :class="['btn-text']">
                <slot></slot>
            </div>
        </button>
    </div>
</template>
<script>
export default {
    name: "MISAButtonIcon",
    props: ["Type", "Icon"]
}
</script>
<style>
@import "../../css/layout/button.css";
</style>
