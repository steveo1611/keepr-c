<template>
<div class="vaults bgImg">
    <div class="row justify-content-center">
      <div class="col-6 card">
        <div class="vault">
          <h1>Add Vaults</h1>
          <form v-on:submit.prevent="addVault" class="form">
            <input class="input" type="text" name="name" placeholder=" Name" id="name" v-model="vault.name">
            <input class="input" type="text" name="description" placeholder=" Description" id="description" v-model="vault.description">
            <button class="btn btn-primary btn-success" type="submit">Create</button>
          </form>
          </div>
          <div>
            <h2>Vault List</h2>
             <div v-for="vault in vaults" class="col-sm-12" :key="vault.name">
               <p>NAME: {{vault.name}}  </p>
              <p>Description: {{vault.description}} </p>
          </div>
          </div>
        </div>
      </div>
</div>

</template>
<!-- will use this space to create the vault dashboards -->
<script>
import router from "../router";
import login from "./login";

export default {
  name: "Vaults",
  data() {
    return {
      vault: {
        name: "",
        description: "",
        userId: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("authenticate");
    this.$store.dispatch("getVaults");
  },

  components: {},
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    addVault() {
      this.$store.dispatch("createVault", this.vault);
    },
    userVaults() {
      this.$store.dispatch("getVaults", this.vaults);
    }
  }
};
</script>
<style>
h2 {
  margin-top: 2rem;
}
</style>

