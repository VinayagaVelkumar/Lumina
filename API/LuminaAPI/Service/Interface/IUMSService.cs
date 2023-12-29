using LuminaAPI.Model.UMS;

namespace LuminaAPI.Service.Interface
{
    public interface IUMSService
    {
        public List<User> GetAll();

        public User GetByID(string id);

        public bool Insert(User user);

        public bool Update(User user);
    }
}
