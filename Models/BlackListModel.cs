using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_item_Management_Web.Models
{
    public class BlackListModel
    {
        
        public int userID { get; set; }
        public DateTime? addDate { get; set; }
        public string reason { get; set; }
        public int staffID { get; set; }
        [Key]
        public string labName { get; set;}
    }
    //     public static DateTime RandomDay()
    // {
    //     Random gen = new Random();
    //     DateTime start = new DateTime(1995, 1, 1);
    //     int range = (DateTime.Today - start).Days;
    //     return start.AddDays(gen.Next(range));
    // }


    // public static string GenerateName(int len)
    // {
    //     Random r = new Random();
    //     string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
    //     string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
    //     string Name = "";
    //     Name += consonants[r.Next(consonants.Length)].ToUpper();
    //     Name += vowels[r.Next(vowels.Length)];
    //     int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
    //     while (b < len)
    //     {
    //         Name += consonants[r.Next(consonants.Length)];
    //         b++;
    //         Name += vowels[r.Next(vowels.Length)];
    //         b++;
    //     }
    //     return Name;
    // }

    // }

}