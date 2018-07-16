<template>
    <div class = "home">
      <div class="row public-keeps">
        <div v-for="keep in keeps" class="col-sm-3" :key="keep.name">
        <div class="card">
              <!-- <img class = "card-img-top" :src="'https://bcw-getter.herokuapp.com/?url=' + keep.contentURL"> NOTE: need to rig something like this for me-->  
              <img class = "card-img-top" :src="keep.contentURLcors || './static/img/placehold.jpg'">  <!-- changed name of initial src file due to cors issues -->
          </div>
        </div>
      </div>
    </div>
</template>

<script>
import router from "../router";
import login from "./login";

export default {
  name: "Home",
  data() {
    return {
      keep: {
        name: "",
        description: "",
        contentURL: ""
      }
    };
  },
  components: {},
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  mounted() {
    //    if (!this.$store.state.user) {
    // if no user id kick to the Login page
    // router.push({ name: "User" }); //
    this.$store.dispatch("getKeeps");
  },

  methods: {
    publicKeeps() {
      this.$store.dispatch(getKeeps, this.keep);
    }
  }
};
</script>
<style>
</style>
