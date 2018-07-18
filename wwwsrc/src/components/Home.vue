<template>
    <div class = "home">
      <div class="row public-keeps">
        <div v-for="keep in keeps" class="col-sm-3">
        <div class="card">
              <!-- <img class = "card-img-top" :src="'https://bcw-getter.herokuapp.com/?url=' + keep.contentURL"> NOTE: need to rig something like this for me-->  
              <img class = "card-img-top" :src="keep.contentURLcors || './static/img/placehold.jpg'"> 
               <!-- changed name of initial src file due to cors issues -->
             
              <span v-if="user">
              <vaults v-show="false"></vaults>
               <button class="btn btn-primary btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Select Vault</button>
                
                <div class="vaultlist" v-if="showDropDown">
                <select v-model="vault.id">
                  <option>choose a vault</option>
                  <option v-for="vault in vaults" :key="vault.id">{{vault.name}}</option>

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
</template>

<script>
import router from "../router";
import login from "./login";
import vaults from "./vaults";

export default {
  name: "Home",
  data() {
    return {
      keep: {
        name: "",
        description: "",
        contentURL: ""
      },
      vault: {
        id: 0,
        name: "",
        description: "",
        userId: ""
      },
      selected: "",
      showDropDown: true,
      vaultlist: "",
      vaultKeeps: {}
    };
  },
  components: {
    vaults
  },
  mounted() {
    this.$store.dispatch("authenticate");
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    publicKeeps() {
      this.$store.dispatch(getKeeps, this.keep);
    },
    addtoVault() {
      console.log("add2V" + this.vault.id);
      this.$store.dispatch(addVK, this.vault.id); //made some changes to add id, not sure if valid
    }
  }
};
</script>
<style>
</style>
