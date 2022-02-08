import SessionEntity from '@/types/api/SessionEntity';
import StoreState, { generateDefaultTransactionState } from './types/StoreState';

const state: StoreState = {
  createSession: generateDefaultTransactionState<SessionEntity>(),
  currentSession: generateDefaultTransactionState<SessionEntity>(),
  user: {
    email: '',
    name: '',
  }
};

export default state;
