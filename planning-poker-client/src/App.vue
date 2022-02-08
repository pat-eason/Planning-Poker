<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title> Planning Poker </v-toolbar-title>
    </v-app-bar>

    <v-main>
      <router-view />
    </v-main>

    <v-footer padless>
      <v-col class="text-center" cols="12">
        © {{ copyrightYear }} — <strong>Pat Eason</strong>
      </v-col>
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class App extends Vue {
  get copyrightYear(): number {
    return new Date().getFullYear();
  }
}
</script>
