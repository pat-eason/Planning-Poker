import EntityBase from "./EntityBase";
import type SessionEntity from "./SessionEntity";

export default interface SessionTaskEntity extends EntityBase {
  createdBy: string;
  name: string;
  session: SessionEntity;
}
