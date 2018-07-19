<template>
    <div class = "home">
      <div class="row public-keeps">
        <div v-for="keep in keeps" class="col-sm-4" :key="keep.id">
         <vaults v-show="false"></vaults>
         <!--
           <a href="https://developer.mozilla.org/en-US/" target="_blank">
  <img src="https://mdn.mozillademos.org/files/6851/mdn_logo.png"
       alt="MDN logo" />
</a>
-->
               
        <div class="card">
             <img class = "card-img-top" :src="keep.contentURLcors || './static/img/placehold.jpg'"> 
               <!-- changed name of initial src file due to cors issues -->
              <span v-if="user">
              <!-- <button class="btn btn-primary vault btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Add To Vault</button> -->
             <button @click="toggleModal(1, keep.id)" :key="keep.id">Add To Vault</button>
              <button class="btn btn-primary btn-success" v-on:click.prevent="viewKeep(keep.id)" type="submit">View<span class="badge badge-light">{{keep.viewed}}</span></button>
              <button class="btn btn-primary btn-success" v-on:submit.prevent="share" type="submit">Share Keep</button>
          </span>
          </div>
        </div>
        
        <modal :toggle="showModal">
          <div slot="header">
           <h3>Select Vault</h3>
        </div>
        <div>
          <ul class="vaultgroup">
            <!-- <li class="vaultlist" v-for="vault in vaults" :key="vault.id" :value="vault.id" @click="addtoVault(vault.id, keep.id)">{{vault.name}}</li> -->
            <li class="vaultlist" v-for="vault in vaults" :key='vault.id'>
            <router-link @click.native="console.log('beeep')" to="home">"holle"</router-link>
              <router-link @click.native="addtoVault(vault.id, keepid)" to="/">{{vault.name}} {{keepid}}</router-link>
               
    
              </li>
          </ul>


        </div>
        </modal>


             <!-- <form> -->
               <!-- <button class="btn btn-primary btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Select Vault</button> -->
                <!-- <button @click="showDropDown">Select Vault</button> -->
                <div class="vaultlist" v-if="showDropDown">
                <!-- <select v-bind:value="vault.id" v-on:change="vault.id = $event.target.value"> -->
                  <select v-model="vault.id">
                  <!-- <select v-bind:value="vault.id"> -->
                  <option>choose a vault</option>
                  <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}} {{keepid}}</option>

                  </select>
                <button class="btn btn-primary btn-success" :key="keep.id" v-on:click.prevent="addtoVault(vault.id, keep.id)" >Add to Vault</button>
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
import router from "../router"
import login from "./login"
import vaults from "./vaults"
import keeps from "./keeps"
import modal from "./modal"

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
      vaultKeeps: {},
      keepid: null,
      showModal: 0
    };
  },
  components: {
    vaults,
    modal
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
    toggleModal(n, id){
      this.keepid = id
      console.log(this.keepid) 
      this.showModal +=n
    },
    viewKeep(id){

      this.$store.dispatch("setviewKeep", id)
      // this.$router.push({ name: "viewKeep" });
    },


    addtoVault(vaultid, keepid) {
      console.log("add2V " + keepid);
      console.log("2V " + this.keep.id );
      this.$store.dispatch("addVK", vaultid, keepid); //made some changes to add id, not sure if valid
    }
  }
};
</script>
<style>
.badge{
  margin-left: 1rem;
}
</style>
