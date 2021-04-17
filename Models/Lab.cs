using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_item_Management_Web.Models //ชื่อ project.ชื่อ Folder.บลาๆ
{
    public class Lab
    {
        public int Id { get; set; } //"Id"will be pk automatically
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}