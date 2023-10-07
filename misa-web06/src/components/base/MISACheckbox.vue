<template>
    <input class="input--checkbox" type="checkbox" v-model="value" :checked="checked" />
    <span class="value-checkbox">{{ TextValue }}</span>
</template>
<script>
export default {
    name: "MISACheckbox",
    props: ["TextValue", "checked", "modelValue"],
    emits: ["checked"],
    data() {
        return {
            value: this.checked,
        }
    },
    watch: {
        value(newValue) {
            this.$emit('checked', newValue, this.modelValue);
        }
    }
}
</script>
<style>
@import "../../css/layout/checkbox.css";
</style>
