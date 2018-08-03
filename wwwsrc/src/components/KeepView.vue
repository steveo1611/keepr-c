<template>
    <div class = "Keepview">
        <div class="row keeps">
            <div class="col-sm-6 offset-sm-3">
                <div class="card">
                    <img class = "card-img-top keepview" :src="activeKeep.contentURL || './static/img/placehold.jpg'"> 
                    <span v-if="user">
                    <button class="btn btn-primary btn-primary" @click="showModal" :key="keep.id">Add To Vault</button>
                    <button class="btn btn-primary btn-success" v-on:click.prevent="goback" type="submit">Back</button>
                    <!-- <button class="btn btn-primary btn-success" v-on:submit.prevent="share" type="submit">Share Keep</button> -->
                    </span>
                </div>
            </div>
        </div>
    <modal v-show="isModalVisible" @close="closeModal"></modal>
    </div>
</template>

<script>
import vaults from "./vaults";
import modal from "./modal";

export default {
  name: "",
  data() {
    return {
      keep: {},
      user: {},
      showKeeps: true,
      vaultlist: '',
      vaultKeeps: {},
      keepid: null,
      vaultid: null,
      // id: null,
      isModalVisible: false,
    };
  },
  components: {
    modal,
    vaults
  },
  mounted() {
    this.$store.dispatch("authenticate");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
     },
    activeKeep() {
      return this.$store.state.activeKeep;
     }
  },
  methods: {
    showModal() {

      this.isModalVisible = true;
      // this.$store.commit("setActiveKeep", keep);
    },
      closeModal() {
        this.isModalVisible = false;
    },
    goback() {
      this.$router.push({ name: "Home" });
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