<template>
  <v-app>
    <Toolbar />

    <v-main>
      <router-view v-if="userIsConfigured" />
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

import ConfigureUserForm from "@/components/ConfigureUserForm.vue";
import Toolbar from "@/components/Toolbar.vue";
import GetterType from "@/store/types/GetterType";

@Component({
  components: {
    ConfigureUserForm,
    Toolbar,
  },
})
export default class App extends Vue {
  get copyrightYear(): number {
    return new Date().getFullYear();
  }

  get userIsConfigured(): boolean {
    return this.$store.getters[GetterType.IS_USER_CONFIGURED];
  }
}
</script>
