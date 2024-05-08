using Clean.Domain.Primitives;

namespace Clean.Domain.Entities
{
    public class Webinar : Entity
    {
        public Webinar(int id, string name, DateTime scheduledOn)
            : base(id)
        {
            Name = name;
            ScheduledOn = scheduledOn;
        }

        private Webinar()
        {
        }

        public string Name { get; private set; }
        public DateTime ScheduledOn { get; private set; }
    }
}
