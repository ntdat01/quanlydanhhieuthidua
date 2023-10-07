<template>
    <div class="main">
        <div class="main--title">
            Danh hiệu thi đua
        </div>
        <div class="main-header">
            <div class="flex-left">
                <m-search Placeholder="Nhập mã hoặc tên danh hiệu...">
                </m-search>
                <m-btn-icon Type="filter" Icon="filter">
                    Bộ lọc
                </m-btn-icon>
            </div>
            <div class="flex-right">
                <m-btn-icon Type="primary" Icon="plus" @click="btnAddOnClick">
                    Thêm danh hiệu
                </m-btn-icon>
            </div>
        </div>
        <div class="main-container" id="style-1">
            <table>
                <tr class="tr--sticky">
                    <th class="checkbox sticky"><input class="input--checkbox" type="checkbox"></th>
                    <th class="emulation">Tên danh hiệu thi đua</th>
                    <th class="code">Mã danh hiệu</th>
                    <th class="object">Đối tượng khen thưởng</th>
                    <th class="level">Cấp khen thưởng</th>
                    <th class="type">Loại phong trào</th>
                    <th class="status">Trạng thái</th>
                </tr>
                <tr class="tr--hover" v-for="(item, id) in emulations" :key="id">
                    <td class="td--sticky">
                        <input class="input--checkbox" type="checkbox">
                    </td>
                    <td>{{ item.EmulationName }}</td>
                    <td>{{ item.EmulationCode }}</td>
                    <td>{{ formatRewardObject(item.RewardObject) }}</td>
                    <td>{{ formatRewardLevel(item.RewardLevel) }}</td>
                    <td>{{ formatMovementType(item.MovementType) }}</td>
                    <td class="action"><span class="status-icon"></span>{{ formatInactive(item.Inactive) }}
                        <div class="row-action" hidden>
                            <div class="action-item">
                                <m-icon Type="edit"></m-icon>
                            </div>
                            <div class="action-item">
                                <m-icon Type="much"></m-icon>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="main-footer">
            <div class="footer-left">
                Tổng số: <span class="count-page">12</span> bản ghi
            </div>
            <div class="footer-right">
                <span class="title-page">Bản ghi/Trang</span>
                <m-dropdown></m-dropdown>
                <div class="count">
                    <span class="count-page">1</span>- <span class="count-page">12</span> bản ghi
                </div>
                <div class="page">
                    <div class="icon icon--prev"></div>
                    <div class="icon icon--next"></div>
                </div>
            </div>
        </div>
    </div>
    <EmulationDetail v-if="showDetailForm" :hideFunction="hideDetailForm"></EmulationDetail>
</template>
<script>
import EmulationDetail from './EmulationDetail.vue';
import formatData from '../../js/formatData';
export default {
    name: 'Emulation',
    components: { EmulationDetail },
    created() {
        this.$_axios.get('https://localhost:7113/api/v1/Emulations')
            .then(res => {
                this.emulations = res.data;
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    },
    methods: {
        /**
         * Đóng form chi tiết
         * Author: NTDat (09/08/2023)
         */
        btnAddOnClick() {
            this.showDetailForm = true;
        },
        /**
         * Đóng form chi tiết
         * Author: NTDat (09/08/2023)
         */
        hideDetailForm() {
            this.showDetailForm = false;
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
        }
    },
    data() {
        return {
            emulations: [],
            showDetailForm: false
        };
    },
};
</script>
<style scoped>
@import "../../css/layout/emulation.css";
</style>
