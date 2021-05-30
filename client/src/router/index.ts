import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import { Search, RegisterUser } from "@/views";
import store from "@/store";
import { Routes } from "@/types";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: Routes.Search,
    component: Search,
  },
  {
    path: "/register",
    name: Routes.Register,
    component: RegisterUser,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

router.beforeEach((to, from, next) => {
  if (to.name !== Routes.Register && !store.state.isAuthenticated)
    next({ name: Routes.Register });
  else next();
});

export default router;
