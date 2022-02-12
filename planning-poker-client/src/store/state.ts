import SessionEntity from "@/types/api/SessionEntity";
import SessionTaskEntity from "@/types/api/SessionTaskEntity";
import SessionTaskVoteEntity from '@/types/api/SessionTaskVoteEntity';
import StoreState, {
  generateDefaultTransactionState,
} from "./types/StoreState";

const state: StoreState = {
  createSession: generateDefaultTransactionState<SessionEntity>(),
  createSessionTask: generateDefaultTransactionState<SessionTaskEntity>(),
  currentSession: generateDefaultTransactionState<SessionEntity>(),
  currentSessionTask: generateDefaultTransactionState<SessionTaskEntity>(),
  currentSessionTaskVote: generateDefaultTransactionState<SessionTaskVoteEntity>(),
  user: {
    email: "",
    name: "",
  },
};

export default state;
