import { KeyValueType, get, post } from "./http-client";
import CreateSessionModel from "@/types/CreateSessionModel";
import SessionEntity from "@/types/api/SessionEntity";
import SessionTaskVoteEntity from '@/types/api/SessionTaskVoteEntity';
import CastVoteForSessionModel from '@/types/CastVoteForSessionModel';

const castVote = async (model: CastVoteForSessionModel): Promise<SessionTaskVoteEntity> => {
  const response = await post<SessionTaskVoteEntity>(`sessions/vote/${model.sessionId}`, {
    email: model.email,
    value: model.vote,
  });
  return response.data;
};

const create = async (model: CreateSessionModel): Promise<SessionEntity> => {
  const response = await post<SessionEntity>("sessions", model as KeyValueType);
  return response.data;
};

const retrieveById = async (sessionId: string): Promise<SessionEntity> => {
  const response = await get<SessionEntity>(`sessions/${sessionId}`);
  return response.data;
};

const sessionsService = {
  castVote,
  create,
  retrieveById,
};

export default sessionsService;
