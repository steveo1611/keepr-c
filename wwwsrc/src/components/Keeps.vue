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
              <button class="btn btn-primary btn-success" type="submit">Add</button>
            <div>
              <input type="checkbox" id="privatecheckbox" v-model="keep.isPublic">
              <label for="checkbox">Marked as public</label>
            </div>
          </form>
        </div>
      </div>
        <div class="container-fluid">
          <h1>Users Keeps</h1>
          <span v-if="currentUser">
           <div class="row personal-keeps justify-content-center">
            <div class="card-columns">
              <div v-for="keep in keeps" :key="keep.name">
                  <vaults v-show="false"></vaults>
                  <div class="card p-3">
                    <img class = "card-img-top" :src="keep.contentURL || './static/img/placehold.jpg'"> 
                    <h3>{{keep.name}}</h3>
                    <p>{{keep.description}}</p> 
                    <button class="btn btn-primary btn-primary" @click="toggleModal(1, keep.id)" :key="keep.id">Add To Vault</button>
                    <button class="btn btn-primary btn-success" v-on:click.prevent="viewKeep(keep.id)" type="submit">View<span class="badge badge-light">{{keep.viewed}}</span></button>
                    <button class="btn btn-primary btn-info" v-on:click.prevent="share" type="submit">Share Keep</button>
                    <template v-if='keep.isPublic == "0"'>            
                      <button class="btn btn-primary btn-danger" v-on:click.prevent="deleteKeep" type="submit">Delete Keep</button>
                    </template>
                  </div>
              </div>
            </div>
          </div>
          </span>
        </div>
        
    <modal :toggle="showModal">
      <div slot="header">
        <h3>Select Vault</h3>
      </div>
      <div>
        <ul class="vaultgroup">
          <li class="vaultlist" v-for="vault in vaults" :key='vault.id'>
          <form @submit.prevent="addtoVault(vault.id)">
            <p class="vaultgrp">NAME: {{vault.name}}  </p>
            <p class="vaultgrp">Description: {{vault.description}} </p>
            <!-- <router-link @click.native="addtoVault(vault.id, keepid)" to="/">{{vault.name}} {{keepid}}</router-link> -->
            <button :value="vault.id" class="btn btn-primary btn-success" v-on:click="test()">Select vault</button>
          </form>
          </li>
        </ul>
      </div>
    </modal> 
    </div>
    </div>
</template>

<script>
import vaults from "./vaults";
import modal from "./modal";

export default {
  name: "keep",
  data() {
    return {
      keep: {
        name: "",
        description: "",
        contentURL: "",
        isPublic: 1,
        viewed: 0
      },
      vault: {
        name: "",
        description: "",
        userId: "",
        id: 0
      },
      showKeeps: true,
      vaultlist: "",
      vaultKeeps: {},
      keepid: null,
      vaultid: null,
      showModal: 0
    };
  },
  components: {
    vaults,
    modal
  },
  mounted() {
    this.$store.dispatch("authenticate");
   // this.$store.dispatch("usercreatedkeeps");
  },
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
    vaults() {
       return this.$store.state.vaults;
    },
    keeps() {
      return this.$store.state.keeps;
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
    addKeeps() {
      this.$store.dispatch("createKeeps", this.keep);
    },
    getUserKeeps() {
      this.$store.dispatch("usercreatedkeeps", this.keep);
    },
    viewKeep(id) {
      this.$store.dispatch("setviewKeep", id);
      // this.$router.push({ name: "viewKeep" });
    },

    addtoVault(vid) {
      this.vaultid = vid
      var payload = {
        vaultId: this.vaultid,
        keepId: this.keepid,
        userId: this.$store.state.user.id
      }
      this.$store.dispatch("addVK", payload) 
    }
  }
};
</script>
<style>
.badge {
  margin-left: 1rem;
}
.card-columns {
  display: inline-block;
  column-count: 4;
  }
</style>