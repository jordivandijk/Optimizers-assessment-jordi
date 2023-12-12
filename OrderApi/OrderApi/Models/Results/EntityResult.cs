using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OrderApi.Models.Results
{
    public class EntityResult<T> : Result where T : Entity 
    {
        public EntityResult(T value)
        {
            Value = value;
        }

        public EntityResult(string error, Guid trace)
            :base(error, trace)
        {

        }

        public T? Value { get; set; }
    }
}
