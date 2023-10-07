import { createApp } from "vue";
import App from "./App.vue";
import Demo from "./components/demo/Demo.vue"
import MISAInput from "./components/base/MISAInput.vue"
// import TheMain from "./components/layout/TheMain.vue"
import MISAIcon from "./components/base/MISAIcon.vue"
import MISAButton from "./components/base/MISAButton.vue"
import MISASearch from "./components/base/MISASearch.vue"
import MISATooltip from "./components/base/MISATooltip.vue"
import MISAButtonIcon from "./components/base/MISAButtonIcon.vue"
import MISACombobox from "./components/base/MISACombobox.vue"
import MISACheckbox from "./components/base/MISACheckbox.vue"
import MISADropdown from "./components/base/MISADropdown.vue"
import MISATextarea from "./components/base/MISATextarea.vue"
import EmulationDetail from "./views/emulation/EmulationDetail.vue"
import misaEnum from "./js/enum"

import axios from 'axios';
import router from "./router/router";
const app = createApp(App);
app.component("m-demo", Demo);
// app.component("TheMain", TheMain);
app.component("m-search", MISASearch);
app.component("m-checkbox", MISACheckbox);
app.component("m-dropdown", MISADropdown);
app.component("m-tooltip", MISATooltip);
app.component("m-input", MISAInput);
app.component("m-btn-icon", MISAButtonIcon);
app.component("m-textarea", MISATextarea);
app.component("m-icon", MISAIcon);
app.component("m-button", MISAButton);
app.component("m-combobox", MISACombobox);
app.component("EmulationDetail", EmulationDetail);
app.config.globalProperties.$_axios = axios;
app.config.globalProperties.$_enum = misaEnum;
app.use(router)
app.mount("#app");
