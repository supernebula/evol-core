
namespace Evol.Common.Logging
{
    public struct EventId
    {
        public EventId(int id, string name = null)
        {
            Id = id;
            Name = name;
        }


        public int Id { get; private set; }
        public string Name { get; }

        public override string ToString()
        {
            if (this.Name != null)
            {
                return this.Name;
            }
            return this.Id.ToString();
        }

        public static implicit operator EventId(int i)
        {
            return new EventId(i);
        }
    }
}
