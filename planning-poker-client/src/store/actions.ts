import { ActionContext, ActionTree } from 'vuex';

import ActionType from './types/ActionType';
import MutationType from './types/MutationType';
import StoreState from './types/StoreState';
import Router from '@/router';
import sessionsService from '@/services/SessionsService';
import CreateSessionModel from '@/types/CreateSessionModel';
import UserModel from '@/types/UserModel';

type StoreActionContext = ActionContext<StoreState, StoreState>;

export interface Actions {
  [ActionType.CREATE_SESSION](context: StoreActionContext, payload: CreateSessionModel): Promise<void>;
  [ActionType.RETRIEVE_SESSION_BY_ID](context: StoreActionContext, sessionId: string): Promise<void>;
  [ActionType.SET_USER](context: StoreActionContext, payload: UserModel): void;
}

const executeApiRequest = async (context: StoreActionContext, loadingMutation: string, errorMutation: string, callback: () => Promise<void>): Promise<void> => {
  context.commit(loadingMutation, true);
  context.commit(errorMutation, null);
  try {
    await callback();
  } catch (err) {
    context.commit(errorMutation, err);
  }
  context.commit(loadingMutation, false);
}

const createSession = async (context: StoreActionContext, payload: CreateSessionModel): Promise<void> => {
  await executeApiRequest(
    context,
    MutationType.SET_CREATE_SESSION_LOADING,
    MutationType.SET_CREATE_SESSION_ERROR,
    async () => {
      const response = await sessionsService.create(payload);
      Router.push({
        name: 'Session',
        params: { sessionId: response.id },
      });
    },
  );
}

const retrieveSessionById = async (context: StoreActionContext, sessionId: string): Promise<void> => {
  await executeApiRequest(
    context,
    MutationType.SET_RETRIEVE_SESSION_LOADING,
    MutationType.SET_RETRIEVE_SESSION_ERROR,
    async () => {
      const response = await sessionsService.retrieveById(sessionId);
      context.commit(MutationType.SET_CURRENT_SESSION, response);
    },
  );
}

const setUser = (context: StoreActionContext, payload: UserModel): void => {
  context.commit(MutationType.SET_USER_EMAIL, payload.email);
  context.commit(MutationType.SET_USER_NAME, payload.name);
}

const actions: ActionTree<StoreState, StoreState> & Actions = {
  [ActionType.CREATE_SESSION]: createSession,
  [ActionType.RETRIEVE_SESSION_BY_ID]: retrieveSessionById,
  [ActionType.SET_USER]: setUser,
};

export default actions;
