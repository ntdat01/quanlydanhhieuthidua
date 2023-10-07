<template>
    <div>
        <div class="label-cbo">
            <label for="">{{ TextLabel }}<span class="require" v-if="Require">*</span></label>
        </div>
        <div class="combobox">
            <input class="input-cbo" type="text" v-model="itemValue.Name">
            <div class="icon icon--dropdown icon-cbo" @click="dropdownOnClick"></div>
        </div>
        <div class="cbo-content" v-if="showList">
            <ul>
                <li v-for="(item, id) in dropdowmItems" :key="item.itemId" @click="handleItemClick(item)">{{ item.itemName
                }}</li>
            </ul>
        </div>
    </div>
</template>
<script>
export default {
    name: "MISACombobox",
    props: ["Require", "TextLabel", "showList", "dropdowmItems"],
    methods: {
        // hiển thị List cấp khen thưởng
        dropdownOnClick() {
            this.showList = !this.showList
        },
        // khi chọn cấp khen thưởng => đóng List
        handleItemClick(item) {
            this.itemValue = item;
            this.showList = false;
            this.$emit("change", item);
            console.log(item);
        }
    },
    data() {
        return {
            showList: false,

            itemValue: {}
        }
    }, created() {

    }
}
</script>
<style scoped>
@import "../../css/layout/combobox.css";
</style>
