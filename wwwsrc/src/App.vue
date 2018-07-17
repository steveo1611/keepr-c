<template>
  <div id="app">
        <nav class="navbar navbar-dark bg-primary top-header format">
        <div>
          <img src="./assets/logo.png">
        <router-link :to="{ name: 'Home'}" class="navbar-brand">
         <a>Home</a>
        </router-link>
        <span v-if="user">
          <router-link :to="{ name: 'Vaults'}" class="navbar-brand">
            <a>Manage Vaults</a>
          </router-link>
          <router-link :to="{ name: 'Keeps'}" class="navbar-brand">
            <a>Manage Keeps</a>
          </router-link>
        </span>
        </div>
        <a class="navbar-brand" @click="login" v-if="!(user.username)">
        <button type="button" class="btn btn-outline-light">Sign In/Register</button>
        </a>
      <div v-if="user.username" class="d-flex flex-column">
        <a class="navbar-brand">User: {{user.username}}</a>
        <a class="navbar-brand btn btn-outline-light" @click="logOut">Sign out</a>
      </div>
    </nav>
    <router-view/>
  </div>
</template>

<script>
export default {
  name: "App",
  mounted() {
    this.$store.dispatch("authenticate");
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },

  methods: {
    home() {
      this.$route.push({ name: "Home" });
    },
    login() {
      this.$router.push({ name: "User" });
    },
    logOut() {
      this.$store.dispatch("logOut");
    },
    keeps() {
      this.$router.push({ name: "Keeps" });
    },
    vaults() {
      this.$router.push({ name: "vaults" });
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  /* margin-top: 60px; */
}
</style>
