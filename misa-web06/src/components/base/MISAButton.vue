<template>
    <div>
        <button :class="['btn', 'btn--' + Type]">
            <div :class="['btn-text']">
                <slot></slot>
            </div>
        </button>
    </div>
</template>
<script>
export default {
    name: "MISAButton",
    props: ["Type"]
}
</script>
<style>
@import "../../css/layout/button.css";
</style>
