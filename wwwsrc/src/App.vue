<template>
  <div id="app">
        <nav class="navbar navbar-dark bg-primary top-header format">
        <a href="#" class="navbar-left">
        <router-link :to="{ name: 'Home'}" class="navbar-brand">
            <a>Home</a>
        </router-link>
        <a class="navbar-brand" @click="keeps" v-if="!(user)"><button type="button" class="btn btn-outline-light">Create keeps</button></a>
        
       </a>
 
        <a class="navbar-brand" @click="login" v-if="!(user)"><button type="button" class="btn btn-outline-light">Sign In/Login</button></a>
      <div v-if="user" class="d-flex flex-column">
        <a class="navbar-brand">User: {{user.userName}}</a>
        <a class="navbar-brand btn btn-outline-light" @click="signOut">Sign out</a>
      </div>
    </nav>
    
    <h1> Hello Heaven</h1>
    <router-view/>

  </div>
</template>

<script>
export default {
  name: 'App',
  computed: {
    user() {
      return this.$store.state.user
    }
  },

  methods: {
    login() {
      this.$router.push({ name: 'User'})
    },
    signOut() {
      this.$store.dispatch('signOut')
    },
    keeps() {
      this.$router.push({ name: 'Keeps'})
    }
  }
};
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
