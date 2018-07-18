<template>
    <div class = "Keepview">
      <div class="row keeps">
        <div class="col-sm-6 offset-sm-3">
        <div class="card">
             <img class = "card-img-top keepview" :src="keep.contentURL || './static/img/placehold.jpg'"> 
               <!-- changed name of initial src file due to cors issues -->
              <span v-if="user">
              <button class="btn btn-primary vault btn-success" v-on:click.prevent="showDropDown=!showDropDown" type="submit">Select Vault</button>
             
              <button class="btn btn-primary btn-success" v-on:click.prevent="goback" type="submit">Back</button>
              <button class="btn btn-primary btn-success" v-on:submit.prevent="share" type="submit">Share Keep</button>
          </span>
          </div>
        </div>
</div>
    </div>
</template>

<script>
    export default {
        name: 'KeepView',
        mounted(){
    this.$store.dispatch("authenticate");
        },
        data(){
        return{
            keep: {},
            user: {}
        };
        },
        computed: {},
        methods:{
        goback(){
            this.$router.push({ name: "Home" });
    },
        }

        
    }
</script>

<style>
.keepview {
    display: block;
    margin-left: auto;
    margin-right: auto;
    width: 100%; 
}
</style>