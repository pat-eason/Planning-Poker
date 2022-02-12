<template>
  <v-row>
    <v-col>
      <v-btn-toggle v-model="vote" @change='castVote'>
        <v-btn
          v-for='voteOption in voteOptions'
          :key='voteOption'
          :value='voteOption'
          color='primary'
          dark
        >
          {{voteOption}}
        </v-btn>
      </v-btn-toggle>
    </v-col>
  </v-row>
</template>

<script lang="ts">
import { Component, Emit, Vue } from "vue-property-decorator";

import appConstants from "@/constants/app.constants";

@Component
export default class CastVoteForm extends Vue {
  vote = 0;

  voteOptions = appConstants.voteOptions;

  mounted() {
    this.vote = this.voteOptions[0];
  }

  @Emit()
  castVote(): number {
    return this.vote;
  }
}
</script>
