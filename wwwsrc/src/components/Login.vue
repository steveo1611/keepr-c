<template>
  <div class="user">
    <div class="row justify-content-center">
      <div class="col-6 card">
        <div class="login" v-if="showLogin">
          <h1>Login</h1>
          <form v-on:submit.prevent="login" class="form">
            <input class="input" type="email" name="email" placeholder=" e-mail" id="email" v-model="user.email">
              <input class="input" type="password" name="password" placeholder=" password" id="name" v-model="user.password">
                <button class="btn btn-primary btn-success" type="submit">Login</button>
              </form>
              <br>
              <p class="user">
                Create Account:
                <em @click="toggle">
                  <button type="button" class="btn btn-danger">Register</button>
                </em>
              </p>
            </div>
        <div class="register" v-if="!showLogin">
          <h1>Register</h1>
          <form v-on:submit.prevent="register">
            <input class="input" type="email" name="email" placeholder=" e-mail" id="email" v-model="user.email">
              <input class="input" type="text" name="name" placeholder="name" id="name" v-model="user.UserName">
                <input class="input" type="password" name="password" placeholder="password" id="name" v-model="user.password">
                  <button class="btn btn-primary btn-danger" type="submit">Register</button>
            </form>
          <br>
            <div>
            </div>
            <br>
              <p>
                Already a user?
                <em @click="toggle">
                  <button class="btn btn-primary btn-success" type="submit">Login</button>
                </em>
              </p>
            </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "login",
  mounted() {
    this.$store.dispatch('authenticate');
  },
  data() {
    return {
      user: {
        Id: '',
        UserName: '',
        Email: ''
      },
      showLogin: true
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.user
    }
  },
  methods: {
    login() {
      this.$store.dispatch("login", this.user)
    },
    register() {
      this.$store.dispatch("register", this.user)
    },
    toggle() {
      this.showLogin = !this.showLogin
    }
  }
};
</script>
<style>
</style>
