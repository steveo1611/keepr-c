<template>
<div class="user bgImg">
    <div class="row justify-content-center">
      <div class="col-6 card">
        <div class="keeps">
          <h1>Add Keeps</h1>
          <form v-on:submit.prevent="addKeeps" class="form">
            <input class="input" type="text" name="name" placeholder=" Name" id="name" v-model="keep.name">
              <input class="input" type="text" name="description" placeholder=" Description" id="description" v-model="keep.description">
              <input class="input" type="url" name="contentURL" placeholder=" contentURL" id="contentURL" v-model="keep.contentURL">
                <button class="btn btn-primary btn-success" type="submit">submit</button>
          </form>
          </div>
        </div>
      </div>
</div>
</template>
<script>
export default {
  name: "keep",
  mounted() {
    this.$store.dispatch('authenticate');
  },
  data() {
    return {
        keep: {
        name: '',
        description: '',
        contentURL: ''
        },
      showKeeps: true
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.user
    },
    createKeeps(){
      return this.$store.state.keep
    }
  },
  methods: {
    toggle() {
      this.showKeeps = !this.showKeeps
    },
    addKeeps(){
      this.$store.dispatch("createKeeps", this.keep);
    }
  }

};
</script>
<style>
</style>