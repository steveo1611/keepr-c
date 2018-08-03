<template>
    <div class = "home">
      <keeps></keeps>
      <vaults></vaults>
    </div>
</template>

<script>
import router from "../router";
import login from "./login";
import vaults from "./vaults";
import keeps from "./keeps";
import keepview from "./keepview";
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
