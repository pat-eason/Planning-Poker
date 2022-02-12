<template>
  <v-container>
    <v-overlay v-if="currentSessionLoading" :value="true">
      <v-progress-circular indeterminate color="primary" />
    </v-overlay>

    <v-sheet v-if="currentSessionError">
      <p>Something went wrong while looking up your Session</p>
      <v-btn color="primary" text @click="backToHome"> Go back Home </v-btn>
    </v-sheet>

    <template v-if="currentSession">
      <v-row>
        <v-col>
          <v-card>
            <v-card-title> Create New Session Task </v-card-title>
            <v-card-subtitle v-if="currentSession">
              Creating a new Session Task will close out the current Session
              Task.
              <strong>Be sure you're ready to move on!</strong>
            </v-card-subtitle>

            <v-card-text>
              <CreateSessionTaskForm
                :sessionId="currentSession.id"
                @submit-form="createSessionTask"
              />
            </v-card-text>
          </v-card>
        </v-col>
        <v-col>
          <v-card v-if="currentSessionTask">
            <v-card-title> Cast your Vote </v-card-title>
            <v-card-text>
              <CastVoteForm @cast-vote='createSessionTaskVote' />
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
    </template>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import CastVoteForm from "@/components/CastVoteForm.vue";
import CreateSessionTaskForm from "@/components/CreateSessionTaskForm.vue";
import SessionEntity from "@/types/api/SessionEntity";
import ActionType from "@/store/types/ActionType";
import SessionTaskEntity from "@/types/api/SessionTaskEntity";
import CastVoteForSessionModel from "@/types/CastVoteForSessionModel";
import CreateSessionTaskModel from "@/types/CreateSessionTaskModel";
import UserModel from '@/types/UserModel';
import { joinSession } from '@/services/SignalRService';

@Component({
  components: {
    CastVoteForm,
    CreateSessionTaskForm,
  },
})
export default class SessionView extends Vue {
  async mounted(): Promise<void> {
    await this.retrieveSession();
  }

  get sessionId(): string {
    const { sessionId } = this.$route.params;
    return sessionId as string;
  }

  get currentSessionLoading(): boolean {
    return this.$store.state.currentSession.isLoading;
  }

  get currentSessionError(): Error | null {
    return this.$store.state.currentSession.error;
  }

  get currentSession(): SessionEntity | null {
    return this.$store.state.currentSession.data;
  }

  get currentSessionTask(): SessionTaskEntity | null {
    return this.$store.state.currentSessionTask.data;
  }

  get currentUser(): UserModel {
    return this.$store.state.user;
  }

  backToHome(): void {
    this.$router.replace({ name: "Home" });
  }

  async createSessionTask(model: CreateSessionTaskModel): Promise<void> {
    await this.$store.dispatch(ActionType.CREATE_SESSION_TASK, model);
  }

  async createSessionTaskVote(vote: number): Promise<void> {
    if (!this.currentSession) {
      return;
    }
    const payload: CastVoteForSessionModel = {
      email: this.currentUser.email,
      sessionId: this.currentSession.id,
      vote,
    }
    this.$store.dispatch(ActionType.CAST_VOTE, payload);
  }

  async retrieveSession(): Promise<void> {
    await this.$store.dispatch(
      ActionType.RETRIEVE_SESSION_BY_ID,
      this.sessionId
    );
  }
}
</script>
