<template>
  <div>
    SessionView: {{sessionId}}

    <pre>
      {{session}}
    </pre>
  </div>
</template>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';

import SessionEntity from '@/types/api/SessionEntity';
import ActionType from '@/store/types/ActionType';

@Component
export default class SessionView extends Vue {
  async mounted(): Promise<void> {
    await this.retrieveSession();
  }

  get sessionId(): string {
    const { sessionId } = this.$route.params;
    return sessionId as string;
  }

  get session(): SessionEntity | null {
    return this.$store.state.currentSession.data;
  }
  
  async retrieveSession(): Promise<void> {
    await this.$store.dispatch(ActionType.RETRIEVE_SESSION_BY_ID, this.sessionId);
  }
}
</script>
