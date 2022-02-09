import SessionEntity from "@/types/api/SessionEntity";
import SessionTaskEntity from "@/types/api/SessionTaskEntity";

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

export default interface StoreState {
  createSession: ApiTransactionType<SessionEntity>;
  createSessionTask: ApiTransactionType<SessionTaskEntity>;
  currentSession: ApiTransactionType<SessionEntity>;
  currentSessionTask: ApiTransactionType<SessionTaskEntity>;
  user: StoreStateUser;
}
