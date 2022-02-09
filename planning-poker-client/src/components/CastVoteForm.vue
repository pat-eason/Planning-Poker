<template>
  <v-form @submit.prevent="submitForm">
    <v-row>
      <v-col>
        <v-btn-toggle
          v-model="model.vote"
          mandatory
        >
          <v-btn
            v-for='voteOption in voteOptions'
            :key='voteOption'
            color='primary'
            dark
          >
            <v-icon :value='voteOption'>{{voteOption}}</v-icon>
          </v-btn>
        </v-btn-toggle>
      </v-col>
    </v-row>
  </v-form>
</template>

<script lang="ts">
import { Component, Emit, Prop, Vue, Watch } from "vue-property-decorator";

import appConstants from "@/constants/app.constants";
import CastVoteForSessionTaskModel from "@/types/CastVoteForSessionTaskModel";

@Component
export default class CastVoteForm extends Vue {
  @Prop({ type: String, required: true })
  sessionTaskId!: string;

  model: CastVoteForSessionTaskModel = {
    email: this.currentUserEmail,
    sessionTaskId: this.sessionTaskId,
    vote: 0,
  };

  voteOptions = appConstants.voteOptions;

  mounted() {
    this.model.email = this.currentUserEmail;
    this.model.vote = this.voteOptions[0];
  }

  get currentUserEmail(): string {
    return this.$store.state.user.email;
  }

  get currentSessionTaskId(): string {
    return this.$store.state.currentSessionTask.id;
  }

  @Emit()
  submitForm(): CastVoteForSessionTaskModel {
    console.log("submitForm", this.model);
    return this.model;
  }

  @Watch('model', { immediate: true, deep: true })
  public modelChanged(newVal: CastVoteForSessionTaskModel, oldVal: CastVoteForSessionTaskModel): void {
    console.log('modelChanged', newVal, oldVal);
    if (newVal.vote != oldVal.vote) {
      this.submitForm();
    }
  }
}
</script>
