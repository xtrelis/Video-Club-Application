using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Club_Application
{
    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public int Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public DateTime DateTimeNow;
        public string LastUpdate;
        public int Category { get; set; }

        public Movie(int id, string title, string description, int releaseYear, int languageId, int rentalDuration, decimal rentalRate, 
            int length, decimal replacementCost, string rating, string specialFeatures, int category)
        {
            Id = id;
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            LanguageId = languageId;
            RentalDuration = rentalDuration;
            RentalRate = rentalRate;
            Length = length;
            ReplacementCost = replacementCost;
            Rating = rating;
            SpecialFeatures = specialFeatures;
            DateTimeNow = DateTime.Now;
            LastUpdate = DateTimeNow.ToString("yyyy-MM-dd H:mm:ss");
            Category = category;
        }
    }
}
