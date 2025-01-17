namespace Projeto1.Components.Roteamento.Users
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }

    public class UserService : IUserService
    {
        private List<User> users = new()
        {
            new User {Id= 1, Name = "Sera sera", Email="emailTeste@foo.com"},
            new User {Id= 2, Name = "Ciclano", Email="asd@email.org"},
            new User {Id= 3, Name = "Fulano", Email="future@osd.com"}

        };

        public Task<List<User>> GetAllUserAsync()
        {
            return Task.FromResult(users);
        }
         
        public Task<User> GetUserByIdAsync(int id)
        {
            return Task.FromResult(users.FirstOrDefault(users => users.Id == id));
        }

    }
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUserAsync();

    }
}
