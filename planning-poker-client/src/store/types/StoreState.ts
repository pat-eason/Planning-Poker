import SessionEntity from "@/types/api/SessionEntity";
import SessionTaskEntity from "@/types/api/SessionTaskEntity";
import SessionTaskVoteEntity from '@/types/api/SessionTaskVoteEntity';

type NullableEntity<T> = T | null;

export interface ApiTransactionType<T> {
  error: NullableEntity<Error>;
  isLoading: boolean;
  data: NullableEntity<T>;
}

export const generateDefaultTransactionState = <
  T
>(): ApiTransactionType<T> => ({
  error: null,
  isLoading: false,
  data: null,
});

export interface StoreStateUser {
  email: string;
  name: string;
}

export interface StoreSignalRSession {
  task: any;
  users: any[];
  votes: any[];
}

export default interface StoreState {
  createSession: ApiTransactionType<SessionEntity>;
  createSessionTask: ApiTransactionType<SessionTaskEntity>;
  currentSession: ApiTransactionType<SessionEntity>;
  currentSessionTask: ApiTransactionType<SessionTaskEntity>;
  currentSessionTaskVote: ApiTransactionType<SessionTaskVoteEntity>;
  user: StoreStateUser;
}
