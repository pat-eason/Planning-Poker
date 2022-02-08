import ResponseEnvelope from '@/types/api/ResponseEnvelope';

const {
  VUE_APP_API_BASE_PATH,
  VUE_APP_API_DOMAIN
} = process.env;

export type KeyValueType = Record<string, any>;

export enum RequestMethod {
  GET = 'GET',
  POST = 'POST',
  PUT = 'PUT',
  DELETE = 'DELETE'
}

const defaultHeaders: KeyValueType = {
  'content-type': "application/json",
};

const generateAPIUrl = (
  requestUrl: string,
  query: KeyValueType = {}
): string => {
  const url = new URL(
    `${VUE_APP_API_BASE_PATH}/${requestUrl}`,
    VUE_APP_API_DOMAIN,
  );
  for (const k in query) {
    url.searchParams.append(k, query[k]);
  }
  return url.href;
};

const executeRequest = async<T> (
  url: string,
  method: RequestMethod,
  body: KeyValueType = {},
  params: KeyValueType = {},
  headers: KeyValueType = {}
): Promise<ResponseEnvelope<T>> => {
  const requestOptions: RequestInit = {
    headers: {
      ...defaultHeaders,
      ...headers,
    },
    method,
  };
  if (method === RequestMethod.POST || method === RequestMethod.PUT) {
    requestOptions.body = JSON.stringify(body);
  }
  const response = await fetch(generateAPIUrl(url, params), requestOptions);
  return response.json();
}

const get = async <T>(
  url: string,
  params: KeyValueType = {},
  headers: KeyValueType = {}
): Promise<ResponseEnvelope<T>> => await executeRequest<T>(url, RequestMethod.GET, {}, params, headers);

const post = async <T>(
  url: string,
  body: KeyValueType = {},
  params: KeyValueType = {},
  headers: KeyValueType = {}
): Promise<ResponseEnvelope<T>> => await executeRequest<T>(url, RequestMethod.POST, body, params, headers);

const put = async <T>(
  url: string,
  body: KeyValueType = {},
  params: KeyValueType = {},
  headers: KeyValueType = {}
): Promise<ResponseEnvelope<T>> => await executeRequest<T>(url, RequestMethod.PUT, body, params, headers);

export { get, post, put };
