
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Models
   {
      public class Event
      {
         public string Name { get; set; }
         [FromForm(Name ="desc")]
         public string Description { get; set; }
         public string? ContactEmail {get; set;}
        public int Id { get; set; } 


        public Event()
        {
   
        }
         public Event(string name, string description) : this()
         {
            Name = name;
            Description = description;
         }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Event @event && Id == @event.Id;
        }

        public override string ToString()
         {
            return Name;
         }
      }
   }