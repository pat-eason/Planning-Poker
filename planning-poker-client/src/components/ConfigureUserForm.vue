<template>
  <ValidationObserver ref="observer" v-slot="{ invalid }">
    <v-form @submit.prevent="submitForm">
      <v-card-title> User Config </v-card-title>
      <v-card-subtitle> Let's get some details for you first </v-card-subtitle>

      <v-card-text>
        <v-row>
          <v-col>
            <ValidationProvider
              name="email"
              rules="email|required"
              v-slot="{ errors }"
            >
              <v-text-field
                v-model="model.email"
                :error-messages="errors"
                label="Email"
                outlined
              />
            </ValidationProvider>
          </v-col>
        </v-row>

        <v-row>
          <v-col>
            <ValidationProvider
              name="name"
              rules="required"
              v-slot="{ errors }"
            >
              <v-text-field
                v-model="model.name"
                :error-messages="errors"
                label="Name"
                outlined
              />
            </ValidationProvider>
          </v-col>
        </v-row>
      </v-card-text>

      <v-card-actions>
        <v-spacer />
        <v-btn :disabled="invalid" color="success" type="submit">
          Set User
        </v-btn>
      </v-card-actions>
    </v-form>
  </ValidationObserver>
</template>

<script lang="ts">
import ActionType from "@/store/types/ActionType";
import UserModel from "@/types/UserModel";
import { Component, Vue } from "vue-property-decorator";

@Component
export default class ConfigureUserForm extends Vue {
  model: UserModel = {
    email: "",
    name: "",
  };

  async submitForm(): Promise<void> {
    await this.$store.dispatch(ActionType.SET_USER, this.model);
  }
}
</script>
