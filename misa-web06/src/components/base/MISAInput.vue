<template>
    <div>
        <div>
            <label class="label" :for="Id">{{ TextLabel }}</label>
            <span class="require" v-if="Require">*</span>
        </div>
        <input @input="handleChange" @blur="validate" :class="['input', 'input--' + Type]" type=" text" ref="input" name=""
            :id="Id" :placeholder="Placeholder" v-model="dataValue" autocomplete="off">
        <div class="text-error" v-if="valid">{{ textError }}</div>
    </div>
</template>
<script>

export default {
    name: "MISAInput",
    props: ["Id", "Type", "TextLabel", "Require", "Placeholder", "modelValue", "textError"],
    emits: ["update:modelValue", "onBlurEvent"],
    created() {
        this.dataValue = this.modelValue
    },
    methods: {
        handleChange(event) {
            // let inputValue = event.target.value;
            let inputValue = this.dataValue;
            console.log(inputValue)
            this.$emit("update:modelValue", inputValue);
        },
        validate() {
            if (this.dataValue == "") {
                this.valid = true;
            } else {
                this.valid = false
            }
        }
    },
    data() {
        return {
            valid: false,
            dataValue: "",
        }
    }
}
</script>
<style>
@import "../../css/layout/input.css";
</style>
