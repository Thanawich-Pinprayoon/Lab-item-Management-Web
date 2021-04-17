using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_item_Management_Web.Models //ชื่อ project.ชื่อ Folder.บลาๆ
{
    public class User
    {
        public int Id { get; set; } //"Id"will be pk automatically
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public int Manage { get; set; }

    }
}