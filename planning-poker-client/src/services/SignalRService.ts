import * as signalR from "@microsoft/signalr";

const { VUE_APP_SIGNALR_DOMAIN, VUE_APP_SIGNALR_HUB_PATH } = process.env;

let connection: signalR.HubConnection | null = null;

const init = () => {
  console.log('init', VUE_APP_SIGNALR_HUB_PATH, VUE_APP_SIGNALR_DOMAIN);
  const url = new URL(VUE_APP_SIGNALR_HUB_PATH, VUE_APP_SIGNALR_DOMAIN);
  console.log(url.href);
  connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Debug)
    .withUrl(url.href)
    .build();

  connection.on("EndSession", (payload: any) => {
    receiveEvent('endSession', payload);
  });

  connection.on("EndSessionTask", (payload: any) => {
    receiveEvent('endSessionTask', payload);
  });

  connection.on("ReceiveSessionTask", (payload: any) => {
    receiveEvent('receiveSessionTask', payload);
  });

  connection.on("ReceiveVote", (payload: any) => {
    receiveEvent('receiveVote', payload);
  });

  connection.on("StartSession", (payload: any) => {
    receiveEvent('startSession', payload);
  }); 

  connection.on('TestEvent', () => {
    console.log('received the test event');
  });

  connection.start().catch(err => console.error(err));
}

const joinSession = async (sessionId: string) => {
  if (!connection) {
    throw new Error('SignalR hub has not been initialized!');
  }
  await connection.invoke('clearUserSessions');
  await connection.invoke('joinSessionGroup', sessionId, 'test@test.com', 'Test User');
}

const receiveEvent = (eventName: string, payload: any): void => {
  console.log('receiveEvent', eventName, payload);
}

const sendEvent = async (eventName: string, ...args: any): Promise<void> => {
  console.log('sendEvent', eventName, ...args, connection);
  if (!connection) {
    throw new Error('SignalR hub has not been initialized!');
  }
  await connection.invoke(eventName, ...args);
}


export {
  init,
  joinSession,
  sendEvent,
}
