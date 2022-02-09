<template>
  <v-container>
    <v-card elevation="2">
      <v-card-title> Start a new Session </v-card-title>
      <v-card-text>
        <CreateSessionForm @submit-form="createSession" />
      </v-card-text>

      <v-card-text>
        <hr />
      </v-card-text>

      <v-card-title> Join an existing Session </v-card-title>
      <v-card-text>
        <JoinSessionForm @submit-form="joinSession" />
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import CreateSessionForm from "@/components/CreateSessionForm.vue";
import CreateSessionModel from "@/types/CreateSessionModel";
import JoinSessionForm from "@/components/JoinSessionForm.vue";
import JoinSessionModel from "@/types/JoinSessionModel";

import ActionType from "@/store/types/ActionType";

@Component({
  components: {
    CreateSessionForm,
    JoinSessionForm,
  },
})
export default class Home extends Vue {
  public async createSession(model: CreateSessionModel): Promise<void> {
    await this.$store.dispatch(ActionType.CREATE_SESSION, model);
  }

  public async joinSession(model: JoinSessionModel): Promise<void> {
    console.log("joinSession", model);
  }
}
</script>
