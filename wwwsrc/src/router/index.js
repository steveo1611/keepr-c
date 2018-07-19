import vue from "vue";
import router from "vue-router";
import home from "@/components/home";
import user from "@/components/login";
import keeps from "@/components/keeps";
import vaults from "@/components/vaults";
import keepview from "@/components/keepview";
import modal from "@/components/modal";

vue.use(router);

export default new router({
  routes: [
    {
      path: "/",
      name: "Home",
      component: home
    },
    {
      path: "/login",
      name: "User",
      component: user
    },
    {
      path: "/keeps",
      name: "Keeps",
      component: keeps
    },
    {
      path: "/vaults",
      name: "Vaults",
      component: vaults
    },
    {
      path: "/keepview",
      name: "keepview",
      component: keepview
  }
  ]
});
