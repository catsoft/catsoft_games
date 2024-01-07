using System.Collections.Generic;

namespace App.Models
{
    public enum Menu
    {
        Home,
        About,
        PreOrder,
        Book,
        Services,
        Contacts,
        Blog,
    }

    public static class MenuLinks {
        
       
        public static List<KeyValuePair<Menu, string>> links = new()
        {
            new KeyValuePair<Menu, string>(Menu.Home, "/Home/Index"),
            new KeyValuePair<Menu, string>(Menu.About, "/Home/Index#about"),
            new KeyValuePair<Menu, string>(Menu.PreOrder, "/Home/Index#order"),
            new KeyValuePair<Menu, string>(Menu.PreOrder, "/PreOrder/Index"),
            new KeyValuePair<Menu, string>(Menu.Book, "/Book/Index"),
            new KeyValuePair<Menu, string>(Menu.Services, "/Home/Index#services"),
            new KeyValuePair<Menu, string>(Menu.Contacts, "/Home/Index#Contacts"),
            new KeyValuePair<Menu, string>(Menu.Blog, "/Blog/Index"),
        };
    }
}