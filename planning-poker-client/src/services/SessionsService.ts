import { KeyValueType, get, post } from "./http-client";
import CreateSessionModel from "@/types/CreateSessionModel";
import SessionEntity from "@/types/api/SessionEntity";

const create = async (model: CreateSessionModel): Promise<SessionEntity> => {
  const response = await post<SessionEntity>("sessions", model as KeyValueType);
  return response.data;
};

const retrieveById = async (sessionId: string): Promise<SessionEntity> => {
  const response = await get<SessionEntity>(`sessions/${sessionId}`);
  return response.data;
};

const sessionsService = {
  create,
  retrieveById,
};

export default sessionsService;
