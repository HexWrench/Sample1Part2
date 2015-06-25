using System;
using System.ComponentModel.DataAnnotations;

namespace Sample1Data
{
    public class Player
    {
        public Player()
        {
            Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}