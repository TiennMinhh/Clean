using Clean.Domain.Entities;

namespace Clean.Domain.Abstractions
{
    public interface IWebinarRepository
    {
        void Insert(Webinar webinar);
    }
}
