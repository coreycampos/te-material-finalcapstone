import Vue from "vue";
import Router from "vue-router";
import AllDetails from "../views/AllDetails.vue"
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Logout from "../views/Logout.vue";
import Register from "../views/Register.vue";
import UploadFiles from "../views/UploadFileView.vue";
import store from "../store/index";
import EditCropDetails from "../views/EditCropDetails.vue";
import AllFarmInfo from "../views/AllFarmInfo.vue";
import AddFarmInfo from "../views/AddFarmInfo.vue";
import EditCropPlans from "../views/EditCropPlans.vue";
import Crops from "../views/Crops.vue";
import AddHarvest from "../views/AddHarvest.vue";
import AddLoss from "../views/AddLoss.vue";
import AddSale from "../views/AddSale.vue";
import AddWaste from "../views/AddWaste.vue";
import CurrentInventory from "../views/CurrentInventory.vue";

Vue.use(Router);

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/crops",
      name: "crops",
      component: Crops,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/inventory",
      name: "inventory",
      component: CurrentInventory,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/upload",
      name: "uploadFiles",
      component: UploadFiles,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/AllDetails",
      name: "AllDetails",
      component: AllDetails,
      meta: {
        requiresAuth: true,
      }
    },
    {
      path: "/EditCrop",
      name: "EditCrop",
      component: EditCropDetails,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/AllFarmInfo",
      name: "AllFarmInfo",
      component: AllFarmInfo,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/add/FarmInfo",
      name: "AddFarmInfo",
      component: AddFarmInfo,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/add/Harvest",
      name: "AddHarvest",
      component: AddHarvest,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/add/Loss",
      name: "AddLoss",
      component: AddLoss,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/add/Sale",
      name: "AddSale",
      component: AddSale,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/add/Waste",
      name: "AddWaste",
      component: AddWaste,
      meta:{
        requiresAuth: true
      },
    },
    {
      path: "/edit/CropPlans",
      name: "EditCropPlans",
      component: EditCropPlans,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "*",
      redirect: "/",
    },
  ],
});

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some((x) => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === "") {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
