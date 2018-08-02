<template>
<!-- from the keeps.vue template -->
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


</template>

<script>

export default {
  name: "keep-display",
  mounted() {},
  data() {
      return {
      keep: {
        name: "",
        description: "",
        contentURL: "",
        isPublic: 1,
        viewed: 0
      },
      }
  },
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
      keeps() {
      return this.$store.state.keeps;
    },
        viewcount() {
      return this.$store.state.vcount;
    }
  },
  methods: {
    getUserKeeps() {
      this.$store.dispatch("usercreatedkeeps", this.keep);
    },
    viewKeep(id) {
      this.$store.dispatch("setviewKeep", id);
      // this.$router.push({ name: "viewKeep" });
    },
  }
};
</script>

<style>
</style>