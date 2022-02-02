const { VUE_APP_API_BASE } = process.env;

const generateUrl = (requestUrl: string): string => {
  console.log(process.env);
  console.log('generateUrl', VUE_APP_API_BASE, requestUrl);
  const url = new URL(VUE_APP_API_BASE);
  url.pathname = requestUrl;
  return url.href;
}

const getAll = async<T> (): Promise<T> => {
  const response = await fetch(
    generateUrl('/api/test/'),
    {
      headers: { type: 'application/json' },
      method: 'GET',
    });
  return response.json();
}

const sessionsService = {
  getAll,
};

export default sessionsService;
