<template>
    <div class="form-modal">
        <form action="" class="form">
            <div class="form-header">
                <div class="form-title">Thêm danh hiệu thi đua</div>
                <div class="button-icon">
                    <m-icon Type="help" @mouseover="showTooltip('tooltip-guide')"
                        @mouseleave="hideTooltip('tooltip-guide')">
                    </m-icon>
                    <m-tooltip v-if="isShowTooltip == 'tooltip-guide'" :textTooltip="'Hướng dẫn'"
                        style="min-width: 90px; top: -10px; right: 35px">
                    </m-tooltip>
                    <m-icon Type="close" @click="btnCloseOnClick" @mouseover="showTooltip('tooltip-close')"
                        @mouseleave="hideTooltip('tooltip-close')"></m-icon>
                    <m-tooltip v-if="isShowTooltip == 'tooltip-close'" :textTooltip="'Đóng'"
                        style="min-width: 90px; top: -10px; right: 13px">
                    </m-tooltip>
                </div>
            </div>
            <div class="form-main">
                <m-input tabindex="1" Id="name" Placeholder="Nhập tên danh hiệu" TextLabel="Nhập tên danh hiệu thi đua"
                    textError="Tên danh hiệu không được để trống" :Require="true"
                    @update:modelValue="title.EmulationName = $event;"></m-input>
                <div class="form-information">
                    <div class="form-left">
                        <m-input Id="code" tabindex="2" Placeholder="" TextLabel="Mã danh hiệu" :Require="true"
                            textError="Mã danh hiệu không được để trống"
                            @update:modelValue="title.EmulationCode = $event;"></m-input>
                        <m-combobox tabindex="3" TextLabel="Cấp khen thưởng" Require="true" @change="handleChangeCombobox"
                            :dropdowmItems="dropdowmItemsRewardLevel"></m-combobox>
                    </div>
                    <div class="form-right">
                        <div class="form-group">
                            <label for="" class="object">Đối tượng được khen thưởng <span class="require">*</span></label>
                            <div class="form-checkbox group-one">
                                <div class="check-object">
                                    <m-checkbox tabindex="4" v-model="$_enum.RewardObject.Personal" checked
                                        :TextValue="formatRewardObject($_enum.RewardObject.Personal)"
                                        @checked="textValue"></m-checkbox>
                                </div>
                                <div class="check-collective">
                                    <m-checkbox tabindex="5" v-model="$_enum.RewardObject.Group"
                                        :TextValue="formatRewardObject($_enum.RewardObject.Group)"
                                        @checked="textValue"></m-checkbox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="object">Loại phong trào áp dụng <span class="require">*</span></label>
                            <div class="group-two">
                                <div class="frequency">
                                    <m-checkbox tabindex="6" checked TextValue="Thường xuyên"></m-checkbox>
                                </div>
                                <div class="frequency">
                                    <m-checkbox tabindex="7" TextValue="Theo đợt"></m-checkbox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <m-textarea Id="textarea" tabindex="8" LabelTitle="Ghi chú"></m-textarea>
            </div>
            <div class="footer">
                <m-button @click.prevent="addTitle" tabindex="9" Type="save" @mouseover="showTooltip('tooltip-save')"
                    @mouseleave="hideTooltip('tooltip-save')">
                    Lưu
                </m-button>
                <m-tooltip v-if="isShowTooltip == 'tooltip-save'" :textTooltip="'Ctrl + S'"
                    style="min-width: 60px; top: 410px; right: 34px;">
                </m-tooltip>
                <m-button tabindex="10" Type="outline" @mouseover="showTooltip('tooltip-save-add')"
                    @mouseleave="hideTooltip('tooltip-save-add')">
                    Lưu &amp; thêm mới
                </m-button>
                <m-tooltip v-if="isShowTooltip == 'tooltip-save-add'" :textTooltip="'Ctrl + Shift + S'"
                    style="min-width: 60px; top: 410px; right: 130px;">
                </m-tooltip>
                <m-button tabindex="11" Type="extra">
                    Hủy
                </m-button>
                <button @click.prevent="addTitle">thêm mới test</button>
            </div>
        </form>
    </div>
</template>
<script>
import axios from 'axios';
import formatData from '../../js/formatData';

export default {
    name: "EmulationDetail",
    props: ["hideFunction"],
    methods: {
        // đóng form chi tiết
        btnCloseOnClick() {
            this.hideFunction()
        },
        // hiển thị tooltip
        showTooltip(tooltipId) {
            this.isShowTooltip = tooltipId;
        },
        // ẩn tooltip
        hideTooltip(tooltipId) {
            if (this.isShowTooltip === tooltipId) {
                this.isShowTooltip = null;
            }
        },
        formatRewardObject(value) {
            return formatData.formatRewardObject(value)
        },
        formatRewardLevel(value) {
            return formatData.formatRewardLevel(value)
        },
        formatMovementType(value) {
            return formatData.formatMovementType(value)
        },
        formatInactive(value) {
            return formatData.formatInactive(value)
        },
        textValue(value, textValue) {
            console.log(value, textValue);
        },
        // lấy giá trị cấp khen thưởng
        handleChangeCombobox(item) {
            // this.title.RewardLevel = item.ID;
            console.log(item)
            this.title.RewardLevel = item.itemId;
        },
        addTitle() {
            this.title = {
                "EmulationCode": "ssssdfsfg",
                "EmulationName": "string",
                "RewardLevel": 1,
                "RewardObject": 1,
                "MovementType": 0,
                "Inactive": 0,
                "IsSystem": 0,
                "EmulationNote": "string",
            }

            axios.post('https://localhost:7113/api/v1/Emulations', this.title)
                .then((res) => { console.log("res", res.data) })
        }
    },
    data() {
        return {
            isShowTooltip: null,
            title: {
                "EmulationCode": "ssssdfsfg",
                "EmulationName": "string",
                "RewardLevel": 1,
                "RewardObject": 1,
                "MovementType": 0,
                "Inactive": 0,
                "IsSystem": 0,
                "EmulationNote": "string",
            },
            dropdowmItemsRewardLevel: [{ itemId: 0, itemName: "giari 1" }, { itemId: 1, itemName: "giai 2" }, { itemId: 2, itemName: "giai 3" }],
        }
    },
    watch: {
        title: {
            handler(newTitle, oldTitle) {
                console.log(newTitle);
            },
            deep: true
        }
    },
}
</script>
<style>
@import "../../css/layout/detail.css";
</style>
