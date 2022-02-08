import SessionEntity from '@/types/api/SessionEntity';

type NullableEntity<T> = T | null;

export interface ApiTransactionType<T> {
  error: NullableEntity<Error>;
  isLoading: boolean;
  data: NullableEntity<T>;
}

export const generateDefaultTransactionState = <T>(): ApiTransactionType<T> => ({
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
  currentSession: ApiTransactionType<SessionEntity>;
  user: StoreStateUser,
}
