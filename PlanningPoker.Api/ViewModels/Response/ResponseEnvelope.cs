namespace PlanningPoker.Api.ViewModels.Response
{
    public class ResponseEnvelope<T>
    {
        public ResponseEnvelope(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
