<template>
  <v-form @submit.prevent="submitForm">
    <v-row>
      <v-col>
        <v-text-field
          v-model="model.sessionId"
          label="Session Id"
          outlined
          required
        >
          <template v-slot:append-outer>
            <v-btn color="success" type="submit"> Join Session </v-btn>
          </template>
        </v-text-field>
      </v-col>
    </v-row>
  </v-form>
</template>

<script lang="ts">
import { Component, Emit, Vue } from "vue-property-decorator";

import JoinSessionModel from "@/types/JoinSessionModel";

@Component
export default class CreateSessionForm extends Vue {
  model: JoinSessionModel = {
    sessionId: "",
  };

  @Emit()
  public submitForm(): JoinSessionModel {
    return this.model;
  }
}
</script>
