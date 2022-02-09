<template>
  <ValidationObserver ref="observer" v-slot="{ invalid }">
    <v-form @submit.prevent="submitForm">
      <v-row>
        <v-col>
          <ValidationProvider name="name" rules="required" v-slot="{ errors }">
            <v-text-field
              v-model="model.name"
              :error-messages="errors"
              label="Name"
              outline
            />
          </ValidationProvider>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-btn :disabled="invalid" color="success" type='submit'> Create New Task </v-btn>
        </v-col>
      </v-row>
    </v-form>
  </ValidationObserver>
</template>

<script lang="ts">
import { Component, Emit, Prop, Vue } from "vue-property-decorator";

import CreateSessionTaskModel from "@/types/CreateSessionTaskModel";

@Component
export default class CreateSessionTaskForm extends Vue {
  @Prop({ type: String, required: true })
  sessionId!: string;

  model: CreateSessionTaskModel = {
    email: this.currentUserEmail,
    name: "",
    sessionId: this.sessionId,
  };

  get currentUserEmail(): string {
    return this.$store.state.user.email;
  }

  @Emit()
  submitForm(): CreateSessionTaskModel {
    return this.model;
  }
}
</script>
