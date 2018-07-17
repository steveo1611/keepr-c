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
                <button class="btn btn-primary btn-success" type="submit">submit</button>
                <div>
                <input type="checkbox" id="privatecheckbox" v-model="keep.isPublic">
                <label for="checkbox">Marked as public</label>
                </div>
          </form>
          </div>
          </div>
          <div class="container-fluid">
          <div class="row personal-keeps justify-content-center">
            <div class="col-sm-12">
            <h1>Users Keeps</h1>
            <div class="card-deck"></div>
            <div v-for="keep in keeps" :key="keep.name">
            <div class="card p-3">
              <img class = "card-img-top" :src="keep.contentURLcors || './static/img/placehold.jpg'">  <!-- changed name of initial src file due to cors issues -->
              <h3>{{keep.name}}</h3>
              <p>{{keep.description}}</p>            
            </div>
            </div>
            </div>
            </div>
          </div>
        </div>
        <!-- <div @mouseover="upHere = true" @mouseleave="upHere = false" >
    <h2> Something Something </h2>
    <some-component v-show="upHere"></some-component>
</div> -->
  </div>
  
</template>

<script>
export default {
  name: "keep",
  data() {
    return {
      keep: {
        name: "",
        description: "",
        contentURL: "",
        isPublic: 1
      },
      showKeeps: true,
      upHere: false
    };
  },
  mounted() {
    this.$store.dispatch("authenticate");
    this.$store.dispatch("usercreatedkeeps");
  },
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
    // createKeeps() {
    //   return this.$store.state.keep;
    // },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    toggle() {
      this.showKeeps = !this.showKeeps;
    },
    addKeeps() {
      this.$store.dispatch("createKeeps", this.keep);
    },
    getUserKeeps() {
      this.$store.dispatch("usercreatedkeeps", this.keep);
    }
  }
};
</script>
<style>
</style>