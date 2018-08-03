<template>
    <div class = "Keepview">
        <vaults v-show="false"></vaults>
        <div class="row keeps">
            <div class="col-sm-6 offset-sm-3">
                <div class="card">
                    <img class = "card-img-top keepview" :src="activeKeep.contentURL || './static/img/placehold.jpg'"> 
                    <span v-if="user">
                    <button class="btn btn-primary btn-primary" @click="toggleModal(1, keep.id)" :key="keep.id">Add To Vault</button>
                    <button class="btn btn-primary btn-success" v-on:click.prevent="goback" type="submit">Back</button>
                    <button class="btn btn-primary btn-success" v-on:submit.prevent="share" type="submit">Share Keep</button>
                    </span>
                </div>
            </div>
        </div>
    <!-- <modal :toggle="showModal"> -->
            <modal v-show="isModalVisible" @close="closeModal">
      <div slot="header">
        <h3>??Select Vault</h3>
      </div>
      <div>
        <ul class="vaultgroup">
          <li class="vaultlist" v-for="vault in vaults" :key='vault.id' v-bind="id">
          <form @submit.prevent="addtoVault(vault.id)">
            <p class="vaultgrp">NAME: {{vault.name}}  </p>
            <p class="vaultgrp">Description: {{vault.description}} </p>
            <button :value="vault.id" class="btn btn-primary btn-success" v-on:click="test()">Select vault</button>
          </form>
          </li>
        </ul>
      </div>
    </modal>
    </div>
</template>

<script>
import vaults from "./vaults";
import modal from "./modal";

export default {
  name: "KeepView",
  mounted() {
    this.$store.dispatch("authenticate");
  },
  data() {
    return {
      keep: {},
      user: {},
    //   vaults:[],
      showKeeps: true,
      vaultlist: "",
      vaultKeeps: {},
      keepid: null,
      vaultid: null,
      id: null,
      // showModal: 0,
      isModalVisible: false,
    };
  },
  components: {
      vaults,
      modal
  },
  computed: {
      activeKeep() {
          return this.$store.state.activeKeep;
     },
     vaults() {
         return this.$store.state.vaults;
     }
  },
  methods: {
    goback() {
      this.$router.push({ name: "Home" });
    },
    // toggleModal(n, id) {
    //   this.keepid = id;
    //   this.showModal += n;
    // },
    showModal() {
      this.isModalVisible = true;
    },
        addtoVault(vid) {
      this.vaultid = vid;
      var payload = {
        vaultId: this.vaultid,
        keepId: this.activeKeep.id,
        userId: this.$store.state.user.id
      };
      this.$store.dispatch("addVK", payload);
    }
  }
};
</script>

<style>
.keepview {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 100%;
}
</style>