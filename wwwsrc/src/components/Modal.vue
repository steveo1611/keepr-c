<template>
  <transition id="mod" name="modal-fade">
      <div class="modal-mask" @click="close">
      <div class="modal-backdrop">
        <div class="modal-wrapper">
          <div class="modal" role="dialog" aria-labelledby="modalTitle" aria-describedby="modalDescription">
          <div class="modal-container" @click.capture="handleClicks">

        <header class="modal-header" id="modalTitle">
          <div slot="header">
            <h3>Select Vault</h3>
            <button type="button" class="btn-close" @click="close">x</button>
          </div>
        </header>
             
        <section class="modal-body" id="modalDescription">
          <div slot="body">
            <ul class="vaultgroup">
              <li class="vaultlist" v-for="vault in vaults" :key='vault.id'>
              <form @submit.prevent="addtoVault(vault.id)">
                <p class="vaultgrp">NAME: {{vault.name}}  </p>
                <p class="vaultgrp">Description: {{vault.description}} </p>
                <button class="btn btn-primary btn-success" type="submit">Select vault</button>
              </form>
              </li>
            </ul>
          </div>
        </section>
        <footer class="modal-footer">
          <slot name="footer">
                <!-- <button type="button" class="btn-green" @click="close">close</button> -->
          </slot>
        </footer>
        </div>
        </div>
        </div>
      </div>
      </div>
    </transition>
</template>


<script>
import keeps from "./keeps";
import keepview from "./keepview";
import vaults from "./vaults";

export default {
  name: "modal",
  data() {
    return {
      open: false,
      vault: {
        name: "",
        description: "",
        userId: "",
        id: 0
      },
      isModalVisible: false,
    };
  },
  components: {
    keeps,
    keepview,
    vaults
  },
  computed: {
    vaults() {
       return this.$store.state.vaults;
    },
    activeKeep() {
      return this.$store.state.activeKeep;
     }

  },
  watch: {
    isModalVisible() {

    }

  
    // toggle: {
    //   handler(n) {
    //     if (n > 0) {
    //       this.open = true;
    //     } else {
    //       this.open = false;
    //     }
    //   }
    // }
  },
  methods: {
    handleClicks(e) {
      e.stopPropagation();
    },
    close() {
      this.$emit('close', true);
    },
    
    addtoVault(vid) {
      this.vaultid = vid
      var payload = {
        vaultId: this.vaultid,
        keepId: this.activeKeep.id,
        userId: this.$store.state.user.id
      }
      this.isModalVisible = false;
      this.$store.dispatch("addVK", payload) 
    }
  }
};
</script>

<style>
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.modal-container {
  width: 50rem;
  /* max-height: 25rem; */
  overflow-y: auto;
  margin: 0px auto;
  -webkit-flex: 1 !important;
  -ms-flex: 1 !important;
  padding: 20px 30px;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
  transition: all 0.3s ease;
  font-family: Helvetica, Arial, sans-serif;
}

.modal-backdrop {
  position: fixed;
  top: 0;
  /* bottom: 0; */
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  /* background: #FFFFFF; */
  box-shadow: 2px 2px 20px 1px;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
}

.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}

.modal-header {
  border-bottom: 1px solid #eeeeee;
  color: #4aae9b;
  justify-content: space-between;
}

.modal-footer {
  border-top: 1px solid #eeeeee;
  justify-content: flex-end;
}

.modal-body {
  position: relative;
  padding: 20px 10px;
  overflow-y: auto;
}

.btn-close {
  border: none;
  font-size: 20px;
  padding: 20px;
  cursor: pointer;
  font-weight: bold;
  color: #4aae9b;
  background: transparent;
}

.btn-green {
  color: white;
  background: #4aae9b;
  border: 1px solid #4aae9b;
  border-radius: 2px;
}
</style>