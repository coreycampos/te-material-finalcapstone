<template>
  <div id="app">
    <div id="nav">
      <i class="fas fa-home"></i>
      <router-link class="nav-item" v-bind:to="{ name: 'home' }"
        >Home </router-link
      >
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token"
        >&nbsp;|&nbsp;Register</router-link
      >
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token"
        >&nbsp;|&nbsp;Login</router-link
      >
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token"
        >&nbsp;|&nbsp;Logout</router-link
      >
    </div>
    <router-view />
  </div>
</template>
