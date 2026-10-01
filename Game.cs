using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppFinal
{
    internal class Game
    {
        public string Name { get; set; } = "";
        public string Genre { get; set; } = "";
        public int Year { get; set; }

        public Game(string name, string genre, int year)
        {
            this.Name = name;
            this.Genre = genre;
            this.Year = year;
        }
    }
}
