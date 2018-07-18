<template>
    <div class = "home">
      <div class="row public-keeps">
        <div v-for="keep in keeps" class="col-sm-4" :key="keep.id">
         <vaults v-show="false"></vaults>
        <div class="card">
             <img class = "card-img-top" :src="keep.contentURLcors || './static/img/placehold.jpg'"> 
               <!-- changed name of initial src file due to cors issues -->
              <span v-if="user">
              <button class="btn btn-primary vault btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Select Vault</button>
             
              <button class="btn btn-primary btn-success" v-on:click.prevent="viewKeep(keep.id)" type="submit">View<span class="badge badge-light">{{keep.viewed}}</span></button>
              <button class="btn btn-primary btn-success" v-on:submit.prevent="share" type="submit">Share Keep</button>
          </span>
          </div>
        </div>

             <!-- <form> -->
               <!-- <button class="btn btn-primary btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Select Vault</button> -->
                <!-- <button @click="showDropDown">Select Vault</button> -->
                <div class="vaultlist" v-if="showDropDown">
                <!-- <select v-bind:value="vault.id" v-on:change="vault.id = $event.target.value"> -->
                  <select v-model="vault.id">
                  <!-- <select v-bind:value="vault.id"> -->
                  <option>choose a vault</option>
                  <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}} {{vault.id}}</option>

                  </select>
                <button class="btn btn-primary btn-success" :key="keep.id" v-on:click.prevent="addtoVault(vault.id, keep.id)" type="submit">Add to Vault</button>
                </div>
                <!-- <span>Selected: {{ selected }}</span> -->
         <!-- </div> -->
               
               <!-- <button class="btn btn-primary btn-success" v-on:submit.prevent="view" type="submit">View</button> -->
               <!-- <button class="btn btn-primary btn-success" v-on:submit.prevent="share" type="submit">Share Keep</button> -->
          <!-- </form> -->
         </div>
    </div>
</template>

<script>
import router from "../router";
import login from "./login";
import vaults from "./vaults";
import keeps from "./keeps";

export default {
  name: "Home",
  props:{
    // vault: {}
  },
  data() {
    return {
      keep: {
        name: "",
        description: "",
        contentURL: "",
        id: "",
        viewed: 0
      },
      vault: {
        name: "",
        description: "",
        userId: "",
        id: 0
      },
      selected: "",
      showDropDown: true,
      // vaultlist: "",
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
    },
    viewcount(){
      return this.$store.state.vcount;
    }
  },
  methods: {
    // publicKeeps() {
    //   this.$store.dispatch(getKeeps, this.keep);
    // },
    toggleVaults(){
      this.showDropDown = !this.showDropDown
    },
    viewKeep(id){

      this.$store.dispatch("setviewKeep", id)
      // this.$router.push({ name: "viewKeep" });
    },


    addtoVault(vaultid, keepid) {
      console.log("add2V " + keepid);
      console.log("2V " + this.keep.id );
      this.$store.dispatch("addVK", this.vault); //made some changes to add id, not sure if valid
    }
  }
};
</script>
<style>
</style>
