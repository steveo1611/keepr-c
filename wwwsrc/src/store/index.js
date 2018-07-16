import vue from "vue";
import vuex from "vuex";
import axios from "axios";
import router from "../router";
// var production = !window.location.host.inculdes('localhost');
var baseUrl = "//localhost:5000";

vue.use(vuex);

var server = axios.create({
  baseURL: baseUrl,
  timeout: 3000,
  withCredentials: true
});

export default new vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    setKeeps(state, keeps) {
      state.keeps = keeps;
      },
    setVaults(state, vaults) {
      state.vaults = vaults;
    }
  },
  actions: {
    login({ dispatch, commit }, payload) {
      server
        .post("/account/login", payload)
        .then(user => {
          router.push("/");
          commit("setUser", user);
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    register({ dispatch, commit }, payload) {
      server
        .post("/account/register", payload)
        .then(newUser => {
          router.push("/");
          commit("setUser", newUser);
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    authenticate({ commit, dispatch }, bool) {
      server
        .get("/account/authenticate")
        .then(res => {
          commit("setUser", res.data);
        })
        .catch(res => {
          console.log(res);
        });
    },
    signOut({ commit, dispatch, state }) {
      server
        .delete("/account/logout")
        .then(res => {
          commit("setUser", {});
          router.push({ name: "Home" });
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    getKeeps({ dispatch, commit, state }) {
      server
        .get("/api/keeps")
        .then(res => {
          commit("setKeeps", res.data);
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    createKeeps({ dispatch, commit, state }, payload) {
      server
        .post("/api/keeps", payload)
        .then(res => {
          // console.log(payload)
          commit("setKeeps", payload);
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    usercreatedkeeps({ dispatch, commit, state }) {
      server
        .get("/api/keeps/" + state.user.id)
        .then(res => {
          commit("setKeeps", res.data);
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    getVaults({ dispatch, commit, state }) {
      server
        .get("/api/vaults/" + state.user.id)
        .then(res => {
          commit("setVaults", res.data);
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    createVault({ dispatch, commit }, payload) {
      server
        .post("/api/vaults", payload)
        .then(res => {
          commit("setVaults", payload);
        })
        .catch(res => {
          console.log(res.data);
        });
    }
  }
});
