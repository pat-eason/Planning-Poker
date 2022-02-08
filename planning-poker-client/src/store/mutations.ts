import { MutationTree } from 'vuex';

import MutationType from './types/MutationType';
import StoreState from './types/StoreState';
import SessionEntity from '@/types/api/SessionEntity';

export type Mutations<S = StoreState> = {
  [MutationType.SET_CREATE_SESSION_ERROR](state: S, value: Error | null): void;
  [MutationType.SET_CREATE_SESSION_LOADING](state: S, value: boolean): void;
  [MutationType.SET_RETRIEVE_SESSION_ERROR](state: S, value: Error | null): void;
  [MutationType.SET_RETRIEVE_SESSION_LOADING](state: S, value: boolean): void;
  [MutationType.SET_CURRENT_SESSION](state: S, value: SessionEntity): void;
  [MutationType.SET_USER_EMAIL](state: S, value: string): void;
  [MutationType.SET_USER_NAME](state: S, value: string): void;
}

const setCreateSessionError = (state: StoreState, value: Error | null): void => {
  state.createSession.error = value;
};

const setCreateSessionLoading = (state: StoreState, value: boolean): void => {
  state.createSession.isLoading = value;
};

const setRetrieveSessionError = (state: StoreState, value: Error | null): void => {
  state.currentSession.error = value;
};

const setRetrieveSessionLoading = (state: StoreState, value: boolean): void => {
  state.createSession.isLoading = value;
};

const setCurrentSession = (state: StoreState, value: SessionEntity): void => {
  state.currentSession.data = value;
};

const setUserEmail = (state: StoreState, value: string): void => {
  state.user.email = value;
};

const setUserName = (state: StoreState, value: string): void => {
  state.user.name = value;
};

const mutations: MutationTree<StoreState> & Mutations = {
  [MutationType.SET_CREATE_SESSION_ERROR]: setCreateSessionError,
  [MutationType.SET_CREATE_SESSION_LOADING]: setCreateSessionLoading,
  [MutationType.SET_RETRIEVE_SESSION_ERROR]: setRetrieveSessionError,
  [MutationType.SET_RETRIEVE_SESSION_LOADING]: setRetrieveSessionLoading,
  [MutationType.SET_CURRENT_SESSION]: setCurrentSession,
  [MutationType.SET_USER_EMAIL]: setUserEmail,
  [MutationType.SET_USER_NAME]: setUserName,
};

export default mutations;
