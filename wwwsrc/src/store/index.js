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
    vaults: [],
    vaultKeep: [],
     keepView: {},
     vcount: 0
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
    },
    setvaultKeep(state, vaultKeep) {
      state.vaultKeep = vaultKeep;
    },
    setviewCount(state, vcount) {
      state.vcount = vcount;
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
    logOut({ commit, dispatch, state }, payload) {
      server
        .post("/account/logout")
        .then(res => {
          // commit("setUser", payload);
          router.push({ name: "Home" });
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    setviewKeep({ commit, dispatch, state }, payload) {
      server
        .put("/api/keeps/" + payload)
        .then(res => {
          commit("setviewCount", payload);
          router.push({ name: "keepview" });
        })
        .catch(res => {
          console.log(res);
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
    },
    addVK({ dispatch, commit, store }, payload) {
      console.log(payload);
      server
        .post("/api/vk/", payload)
        .then(res => {
          commit("setvaultKeep", payload);
        })
        .catch(res => {
          console.log(res.data);
        });
    },
    clearResults({ dispatch, commit }) {
      commit("setKeeps", []);
      commit("setVaults", []);
      commit("setvaultKeep", []);
      // commit('setsomething else', [])
    }
  }
});
