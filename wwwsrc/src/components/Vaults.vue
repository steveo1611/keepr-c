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
        </div>
      </div>
</div>





</template>
<!-- will use this space to create the vault dashboards -->
<script>

export default {
  name: "Vaults",
  data() {
    return{
      vault: {
        name: '',
        description: '',
        userId: '' 
      }
    }
  },
  components: {},
  computed: {
    currentUser() {
      return this.$store.state.user
    },
    createVault(){
      return this.$store.dispatch("createVault", this.vault);
    }
  },
  methods: {
    addVault(){
      this.$store.dispatch("createVault", this.vault);
    }
  }
};
</script>
<style>
</style>

