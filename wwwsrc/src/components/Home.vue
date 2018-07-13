<template>
    <div class = "home">
<!-- <h1> hoal dude</h1> -->
<!-- something NO WORKY HERE No getting the image files URLs-->
      <div class="row public-keeps">
        <div class="card">
          <div v-for="keep in keeps" :key="keep.ContentURL">
              <img class = "card-img-top" :src="keep.ContentURL" >
          </div>
        </div>
      </div>
    </div>
</template>

<script>
import router from "../router";
import login from "./Login";

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