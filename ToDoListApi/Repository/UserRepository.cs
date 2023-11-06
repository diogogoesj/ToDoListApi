using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Models;
using ToDoListApi.Repository.Interfaces;

namespace ToDoListApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoListDatabase _userDatabase;
        public UserRepository(ToDoListDatabase userDatabase) { _userDatabase = userDatabase; }



        public async Task<List<UserModel>> GetAll()
        {
            return await _userDatabase.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _userDatabase.Users.FirstOrDefaultAsync(userUnkown => userUnkown.UserId == id);
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _userDatabase.Users.AddAsync(user);
            await _userDatabase.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário de id: {id} não encontrado");
            }

            userById.UserName = user.UserName;
            userById.UserEmail = user.UserEmail;

            _userDatabase.Users.Update(userById);
            await _userDatabase.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário de id: {id} não encontrado");
            }

            _userDatabase.Users.Remove(userById);
            await _userDatabase.SaveChangesAsync();

            return true;
        }


    }
}
