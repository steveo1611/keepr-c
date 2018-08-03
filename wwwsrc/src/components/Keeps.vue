<template>
<div class="user">
    <div class="row justify-content-center">
      <span v-if="$route.name == 'Keeps'">
      <div class="col-12 card">
        <div class="keeps">
          <h1>Add Keep</h1>
          <form @submit.prevent="addKeep" class="form">
            <input required class="input" type="text" name="name" placeholder=" Name" id="name" v-model="keep.name">
            <input required class="input" type="text" name="description" placeholder=" Description" id="description" v-model="keep.description">
            <input required class="input" type="url" name="contentURL" placeholder=" contentURL" id="contentURL" v-model="keep.contentURL">
            <button class="btn btn-primary btn-success" type="submit">Add</button>
            <div>
              <input type="checkbox" id="privatecheckbox" v-model="keep.isPublic">
              <label for="checkbox">Marked as public</label>
            </div>
          </form>
        </div>
      </div>
      </span>
      <div class="container-fluid">
        <span v-if="$route.name == 'Keeps'"> 
          <h1>{{currentUser.username}}'s Keeps</h1>
        </span>
           <div class="row personal-keeps justify-content-center">
            <div class="card-columns">
              <div v-for="keep in keeps" :key="keep.name">
                  <div class="card p-3">
                    <img class = "card-img-top" :src="keep.contentURL || './static/img/placehold.jpg'"> 
                    <h3>{{keep.name}}</h3>
                    <p>{{keep.description}}</p> 
                    <span v-if="currentUser">
                    <button class="btn btn-primary btn-primary" @click="showModal(keep)" :key="keep.id">Add To Vault</button>
                    <button class="btn btn-primary btn-success" @click.prevent="viewKeep(keep)" type="submit">View<span class="badge badge-light">{{keep.viewed}}</span></button>
                    <!-- <button class="btn btn-primary btn-info" @click.prevent="share" type="submit">Share Keep</button> -->
                    <template v-if='keep.isPublic == "0"'>            
                      <button class="btn btn-primary btn-danger" v-on:click.prevent="deleteKeep" type="submit">Delete Keep</button>
                    </template>
                    </span>
                  </div>
              </div>
            </div>
           </div>
          </div>
        </div>
<!-- modal section -->
      <modal v-show="isModalVisible" @close="closeModal"></modal> 
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
        name: '',
        description: '',
        contentURL: '',
        isPublic: 1,
        viewed: 0
      },
      vault: {
        name: '',
        description: '',
        userId: '',
        id: 0
      },
      showKeeps: true,
      vaultlist: '',
      vaultKeeps: {},
      keepid: null,
      vaultid: null,
      isModalVisible: false,
    };
  },
  components: {
    vaults,
    modal
  },
  mounted() {
    this.$store.dispatch("authenticate");
    this.$store.dispatch("usercreatedkeeps");
    this.$store.dispatch("getVaults")
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
    showModal(keep) {
      this.isModalVisible = true;
      this.$store.commit("setActiveKeep", keep);
    },
    closeModal() {
      this.isModalVisible = false;
    },
    addKeep() {
      this.$store.dispatch("createKeep", this.keep);
      this.$store.dispatch("usercreatedkeeps", this.keep);
    },
    getUserKeeps() {
      this.$store.dispatch("usercreatedkeeps", this.keep);
    },
    viewKeep(keep) {
      this.$store.dispatch("setviewKeep", keep);
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