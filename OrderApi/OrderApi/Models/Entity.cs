namespace OrderApi.Models
{
    public class Entity
    {
        public Entity()
        {

        }
        public Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
