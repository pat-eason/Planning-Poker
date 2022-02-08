<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title>
        Planning Poker
      </v-toolbar-title>

      <v-spacer />

      <v-avatar
        v-if='userIsConfigured'
        color="secondary"
        size="46">
        {{userInitials}}
      </v-avatar>
    </v-app-bar>

    <v-main>
      <router-view v-if='userIsConfigured' />
      <v-container v-else>
        <v-card :maxWidth="360" class="mx-auto">
          <ConfigureUserForm />
        </v-card>
      </v-container>
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

import ConfigureUserForm from '@/components/ConfigureUserForm.vue';
import GetterType from '@/store/types/GetterType';

@Component({
  components: {
    ConfigureUserForm,
  },
})
export default class App extends Vue {
  get copyrightYear(): number {
    return new Date().getFullYear();
  }

  get userInitials(): string {
    return this.$store.getters[GetterType.USER_INITIALS];
  }

  get userIsConfigured(): boolean {
    return this.$store.getters[GetterType.IS_USER_CONFIGURED];
  }
}
</script>
