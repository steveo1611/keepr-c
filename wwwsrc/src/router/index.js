import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import User from '@/components/Login'
import Keeps from '@/components/Keeps'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
    path: '/login',
    name: 'User',
    component: User
    },
    {
      path: '/keeps',
      name: 'Keeps',
      component: Keeps
      },
  ]
})
