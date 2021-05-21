using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD_20
{
    class UsersData
    {

        // Статический список пользователей
        public List<User> Data { get; set; }

        /// <summary>
        /// Возвращает копию списка Users, 
        /// где User.Username совпадает с одним из переданных в метод usernames
        /// </summary>
        /// <param name="terms">Список строк - username, испольуемых для поиска</param>
        /// <returns>Отфильтрованный список пользователей</returns>
        public List<User> GetUsersFilteredByUsernames(List<string> usernames)
        {
            var results = Data.Where(u => usernames.Contains(u.Username)).ToList();
            return results;

        }
    }
}
