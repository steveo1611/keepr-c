<template>
    <div class = "home">
      <div class="row public-keeps">
        <div v-for="keep in keeps" class="col-sm-3" :key="keep.name">
        <div class="card">
              <!-- <img class = "card-img-top" :src="'https://bcw-getter.herokuapp.com/?url=' + keep.contentURL"> NOTE: need to rig something like this for me-->  
              <img class = "card-img-top" :src="keep.contentURLcors || './static/img/placehold.jpg'"> 
               <!-- changed name of initial src file due to cors issues -->
             
              <vaults v-show="false"></vaults>
               <span v-if="user">
               <button class="btn btn-primary btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Add to Vault</button>
                
                <div class="vaultlist" v-if="showDropDown">
                <select v-model="vault">
                  <option v-for="vault in vaults">{{vault.name}}</option>

                </select>
                <!-- <span>Selected: {{ selected }}</span> -->
               </div>
               
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
        name: "",
        description: "",
        userId: ""
      },
      selected: '',
      showDropDown: true,
      vaultlist: null
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
    addtoVault(vaultId) {
      this.$store.dispatch(addVK, this.vault._id);  //made some changes to add id, not sure if valid
    }
    // view() {
    //   this.$store.dispatch(viewKeep, this.vault);
    // },
    // share() {
    //   this.$store.dispatch(addVK, this.vault);
    // }
  }
};
</script>
<style>
</style>
