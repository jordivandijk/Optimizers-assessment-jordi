namespace OrderApi.Models.Results
{
    public class Result
    {
        public Result()
        {
            Succes = true;
            TraceId = Guid.NewGuid();
        }
        public Result(string error, Guid trace)
        {
            Error = error;
            TraceId = trace;
        }

        public bool Succes { get; set; }
        public string? Error { get; set; }
        public Guid TraceId { get; set; }
    }
}
