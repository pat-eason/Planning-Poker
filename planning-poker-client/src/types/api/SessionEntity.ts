import EntityBase from './EntityBase';

export default interface SessionEntity extends EntityBase {
  createdBy: string;
  isPrivate: boolean;
  name: string;
  password?: string;
  sessionTasks?: any[];
}
