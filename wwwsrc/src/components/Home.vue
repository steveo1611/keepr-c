<template>
    <div class = "home">
      <keeps></keeps>
      <!-- <div class="row public-keeps">
        <div v-for="keep in keeps" class="col-sm-4" :key="keep.id">
         <vaults v-show="false"></vaults>
        <div class="card">
             <img class = "card-img-top" :src="keep.contentURL || './static/img/placehold.jpg'">  -->
               <!-- changed name of initial src file due to cors issues -->
              <!-- <span v-if="user">
             
             <button @click="toggleModal(1, keep.id)" :key="keep.id">Add To Vault</button>
              <button class="btn btn-primary btn-success" v-on:click.prevent="viewKeep(keep.id, keep)" type="submit">View<span class="badge badge-light">{{keep.viewed}}</span></button>
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
            <li class="vaultlist" v-for="vault in vaults" :key='vault.id' v-bind="id">
              <form @submit.prevent="addtoVault(vault.id)">
              <p class="vaultgrp">NAME: {{vault.name}}  </p>
              <p class="vaultgrp">Description: {{vault.description}} </p> -->
             <!-- <button :value="vault.id" class="btn btn-primary btn-success" v-on:click="go">Select vault</button> -->
              <!-- <button class="btn btn-primary btn-success" v-on:click="toggleModal(1, id)"> Select Vault</button>
              </form>
            </li>
            <button class="btn btn-primary btn-warning" v-on:click="toggleModal(0, 0)">Cancel</button>
          </ul>
        </div>
        </modal>
    </div> -->
    </div>
</template>

<script>
import router from "../router";
import login from "./login";
import vaults from "./vaults";
import keeps from "./keeps";
import modal from "./modal";

export default {
  name: "Home",
  props: {},
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
      vaultid: null,
      showModal: 0,
      id: null,
      activeKeep: {}
    };
  },
  components: {
    vaults,
    keeps,
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
    viewcount() {
      return this.$store.state.vcount;
    }
    
  },
  methods: {
    toggleModal(n, id) {
      this.keepid = id;
      this.showModal += n;
    },

    viewKeep(id, keep) {
      this.$store.commit('setActiveKeep', keep);
      this.$store.dispatch("setviewKeep", id);
    },

    addtoVault(vid) {
      this.vaultid = vid;
      var payload = {
        vaultId: this.vaultid,
        keepId: this.keepid,
        userId: this.$store.state.user.id
      };
      this.$store.dispatch("addVK", payload);
    }
  }
};
</script>
<style>
.badge {
  margin-left: 1rem;
}
</style>
