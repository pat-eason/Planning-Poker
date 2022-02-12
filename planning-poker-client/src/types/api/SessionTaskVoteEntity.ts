import type SessionTaskEntity from './SessionTaskEntity';

export default interface SessionTaskVoteEntity {
  createdBy: string;
  sessionTask: SessionTaskEntity;
  value: number;
}
