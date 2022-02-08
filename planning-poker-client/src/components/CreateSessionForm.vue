<template>
  <v-form @submit.prevent="submitForm">
    <v-row>
      <v-col>
        <v-text-field v-model="model.name" label="Name" outlined required />
      </v-col>
    </v-row>

    <v-row>
      <v-col>
        <v-checkbox
          v-model="model.isPrivate"
          label="Make your Session Private?"
        />
      </v-col>
      <v-col v-if="model.isPrivate">
        <v-text-field v-model="model.password" label="Password" outlined />
      </v-col>
    </v-row>

    <v-row>
      <v-col class="text-right" right>
        <v-btn color="success" type="submit"> Create Session </v-btn>
      </v-col>
    </v-row>
  </v-form>
</template>

<script lang="ts">
import { Component, Emit, Vue } from "vue-property-decorator";

import CreateSessionModel from "@/types/CreateSessionModel";

@Component
export default class CreateSessionForm extends Vue {
  model: CreateSessionModel = {
    email: 'test@test.com', // @TODO replace with store state
    isPrivate: false,
    name: "",
    password: "",
  };

  @Emit()
  public submitForm(): CreateSessionModel {
    return this.model;
  }
}
</script>
