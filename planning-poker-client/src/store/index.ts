import localForage from "localforage";
import Vue from "vue";
import Vuex from "vuex";
import VuexPersistence, { AsyncStorage } from "vuex-persist";

import actions from "./actions";
import getters from "./getters";
import mutations from "./mutations";
import state from "./state";
import StoreState from "./types/StoreState";

Vue.use(Vuex);

const localForageStore = localForage.createInstance({
  description: "Persistent storage for Planning Poker app",
  name: "planningPokerEason",
  version: 1.0,
});

const vuexLocal = new VuexPersistence<StoreState>({
  asyncStorage: true,
  reducer: (state: StoreState) =>
    ({
      user: state.user,
    } as StoreState),
  storage: localForageStore as AsyncStorage,
});

export default new Vuex.Store({
  actions,
  getters,
  mutations,
  modules: {},
  plugins: [vuexLocal.plugin],
  state,
});
