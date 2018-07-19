<template>
<div class="user">
    <div class="row justify-content-center">
      <div class="col-12 card">
        <div class="keeps">
          <h1>Add Keeps</h1>
          <form v-on:submit.prevent="addKeeps" class="form">
            <input class="input" type="text" name="name" placeholder=" Name" id="name" v-model="keep.name">
              <input class="input" type="text" name="description" placeholder=" Description" id="description" v-model="keep.description">
              <input class="input" type="url" name="contentURL" placeholder=" contentURL" id="contentURL" v-model="keep.contentURL">
                <button class="btn btn-primary btn-success" type="submit">submit</button>
                <div>
                <input type="checkbox" id="privatecheckbox" v-model="keep.isPublic">
                <label for="checkbox">Marked as public</label>
                </div>
          </form>
        </div>
      </div>
        <div class="container-fluid">
          <div class="row personal-keeps justify-content-center">
            <vaults v-show="false"></vaults>
            <div class="col-sm-12">
            <h1>Users Keeps</h1>
            <div class="card-deck"></div>
            <div v-for="keep in keeps" :key="keep.name">

            <div class="card p-3">
              <img class = "card-img-top" :src="keep.contentURLcors || './static/img/placehold.jpg'">  <!-- changed name of initial src file due to cors issues -->
              <h3>{{keep.name}}</h3>
              <p>{{keep.description}}</p> 
               
                <span>
             <!-- refactor item: this code is same as in the home component --> 
               <button class="btn btn-primary btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Add To Vault</button>
                <!-- <button @click="showDropDown">Select Vault</button> -->
                <div class="vaultlist" v-if="showDropDown">
                <select v-model="vault">
                  <!-- <option>choose a vault</option> -->
                  <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
                </select>
                <button class="btn btn-primary btn-success" v-on:click.prevent="addtoVault" type="submit">Add to Vault</button>
                </div>
                <!-- <span>Selected: {{ selected }}</span> -->
         <!-- </div> -->
               
               <button class="btn btn-primary btn-success" v-on:submit.prevent="view" type="submit">View</button>
               <button class="btn btn-primary btn-success" v-on:submit.prevent="share" type="submit">Share Keep</button>
          </span>           
            </div>
            </div>
            </div>
            </div>
          </div>
        </div>

  </div>
  
</template>

<script>
import vaults from "./vaults";

export default {
  name: "keep",
  data() {
    return {
      keep: {
        name: "",
        description: "",
        contentURL: "",
        isPublic: 1
      },
      showKeeps: true,
      vault: {},
      selected: "",
      showDropDown: true,
      vaultlist: "",
      vaultKeeps: {},
      vaults: []
    };
  },
    components: {
    vaults
  },
  mounted() {
    this.$store.dispatch("authenticate");
    this.$store.dispatch("usercreatedkeeps");
  },
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
    // createKeeps() {
    //   return this.$store.state.keep;
    // },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    toggle() {
      this.showKeeps = !this.showKeeps;
    },
    addKeeps() {
      this.$store.dispatch("createKeeps", this.keep);
    },
    getUserKeeps() {
      this.$store.dispatch("usercreatedkeeps", this.keep);
    },
    addtoVault(id) {
      console.log("add2V " + this.vault.id);
      this.$store.dispatch(addVK, this.vault); //made some changes to add id, not sure if valid
    }
  }
};
</script>
<style>
</style>