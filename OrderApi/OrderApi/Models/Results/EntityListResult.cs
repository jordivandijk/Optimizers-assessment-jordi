namespace OrderApi.Models.Results
{
    public class EntityListResult<T> : Result where T : Entity
    {
        public EntityListResult(List<T> values)
        {
            Values = values;
            Count = values.Count;
        }

        public EntityListResult(string error, Guid trace)
            :base(error, trace)
        {
            Count = 0;
        }

        public int Count { get; set; }
        public List<T>? Values { get; set; }
    }
}
