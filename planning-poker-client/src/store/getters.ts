import { GetterTree } from 'vuex';
import GetterType from './types/GetterType';
import StoreState from './types/StoreState';

export interface Getters<S = StoreState> {
  [GetterType.IS_USER_CONFIGURED](state: S): boolean;
  [GetterType.USER_INITIALS](state: S): string;
};

const userIsConfigured = (state: StoreState) => !!(state.user.email && state.user.name);

const userInitials = (state: StoreState) => state.user.name
  .split(' ')
  .map(word => word[0])
  .join('');

const getters: GetterTree<StoreState, StoreState> & Getters = {
  [GetterType.IS_USER_CONFIGURED]: userIsConfigured,
  [GetterType.USER_INITIALS]: userInitials,
}

export default getters;
