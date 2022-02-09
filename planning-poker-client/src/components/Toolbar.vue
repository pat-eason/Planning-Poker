<template>
  <v-app-bar app color="primary" dark>
    <v-toolbar-title>
      Planning Poker
      <span v-if="currentSessionName" class="subtitle-1">
        | {{ currentSessionName }}
      </span>
    </v-toolbar-title>

    <v-spacer />

    <v-avatar v-if="userIsConfigured" color="secondary" size="46">
      {{ userInitials }}
    </v-avatar>
  </v-app-bar>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import GetterType from "@/store/types/GetterType";

@Component
export default class Toolbar extends Vue {
  get currentSessionName(): string {
    return this.$store.state.currentSession.data?.name;
  }

  get userIsConfigured(): boolean {
    return this.$store.getters[GetterType.IS_USER_CONFIGURED];
  }

  get userInitials(): string {
    return this.$store.getters[GetterType.USER_INITIALS];
  }
}
</script>
