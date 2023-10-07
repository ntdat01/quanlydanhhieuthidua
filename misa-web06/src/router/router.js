import { createRouter, createWebHistory } from 'vue-router';
import Report from '@/views/report/Report.vue';
import Bonus from '@/views/bonus/Bonus.vue';
import Compete from '@/views/compete/Compete.vue';
import Dashboard from '@/views/dashboard/Dashboard.vue';
import Decision from '@/views/decision/Decision.vue';
import File from '@/views/file/File.vue';
import Instruct from '@/views/instruct/Instruct.vue';
import Setting from '@/views/settingpage/Setting.vue';
import Search from '@/views/search/Search.vue';
import EmulationList from '@/views/emulation/EmulationList.vue';
const routerList = [
    { path: "/category", name: "category", component: EmulationList },
    { path: "/", redirect: { name: "category" } },
    { path: "/bonus", name: "Bonus", component: Bonus },
    { path: "/compete", name: "Compete", component: Compete },
    { path: "/dashboard", name: "Dashboard", component: Dashboard },
    { path: "/decision", name: "Decision", component: Decision },
    { path: "/file", name: "File", component: File },
    { path: "/instruct", name: "Instruct", component: Instruct },
    { path: "/search", name: "Search", component: Search },
    { path: "/setting", name: "Setting", component: Setting },
    { path: "/report", name: "ReportRouter", component: Report },
]
const router = createRouter(
    {
        history: createWebHistory(), routes: routerList
    }
)
export default router;
