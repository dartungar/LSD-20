using System;
using System.Collections.Generic;
using System.Linq;
 

namespace LSD_20
{
    public enum Sex{
      Male,
      Female
    }

    /// <summary>
    /// Модель пользователя, статический список пользователей, 
    /// метод для наполнения этого списка случайно сгенерированными данными
    /// и метод для фильтрации списка на основе поискового запроса
    /// </summary>
    public class User {


        public int Id {get;set;}
        public string Username {get;set;}
        public DateTime Birthday {get;set;}
        public Sex Sex {get;set;}


        public override string ToString()
        {
            return $"{Id}: {Username}";
        }
    }
}
