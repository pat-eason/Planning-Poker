import { get, post, KeyValueType } from "./http-client";
import SessionTaskEntity from "@/types/api/SessionTaskEntity";
import CreateSessionTaskModel from "@/types/CreateSessionTaskModel";

const create = async (
  model: CreateSessionTaskModel
): Promise<SessionTaskEntity> => {
  const response = await post<SessionTaskEntity>(
    "tasks",
    model as KeyValueType
  );
  return response.data;
};

const retrieveById = async (
  sessionTaskId: string
): Promise<SessionTaskEntity> => {
  const response = await get<SessionTaskEntity>(`tasks/${sessionTaskId}`);
  return response.data;
};

const sessionTasksService = {
  create,
  retrieveById,
};

export default sessionTasksService;
