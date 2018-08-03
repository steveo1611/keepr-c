<template>
  <transition id="mod" name="modal-fade">
      <div class="modal-mask" @click="close">
      <div class="modal-backdrop">
        <div class="modal-wrapper">
          <div class="modal" role="dialog" aria-labelledby="modalTitle" aria-describedby="modalDescription">
          <div class="modal-container" @click.capture="handleClicks">

            <header class="modal-header" id="modalTitle">
              <slot name="header">
                default header
              <button type="button" class="btn-close" @click="close">x</button>
              </slot>
            </header>
            <section class="modal-body" id="modalDescription">
              <slot name="body">body default</slot>
            </section>
            <footer class="modal-footer">
              <slot name="footer">
                <button type="button" class="btn-green" @click="close">close</button>
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
  export default {
    name: 'modal',
    props: ['toggle'],
    data(){
      return {
        open: false
      }
    },
    watch: {
      toggle:{
        handler(n){
          if(n > 0){
            this.open = true
          }else{
            this.open = false
          }
      }
    }
    },
    methods: {
      handleClicks(e){
        e.stopPropagation();
      },
      close() {
        this.$emit('close');
      }
    },
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
    background-color: rgba(0, 0, 0, .5);
    display: table;
    transition: opacity .3s ease;
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
    box-shadow: 0 2px 8px rgba(0, 0, 0, .33);
    transition: all .3s ease;
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
    color: #4AAE9B;
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
    color: #4AAE9B;
    background: transparent;
  }

  .btn-green {
    color: white;
    background: #4AAE9B;
    border: 1px solid #4AAE9B;
    border-radius: 2px;
  }
</style>