namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Game
    {
        private ICollection<Guess> bluePlayerGuesses;
        private ICollection<Guess> redPlayerGuesses;

        public Game()
        {
            this.GameState = GameState.WaitingForOpponent;
            this.bluePlayerGuesses = new HashSet<Guess>();
            this.redPlayerGuesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BluePlayerId { get; set; }

        public virtual User BluePlayer { get; set; }

        public string RedPlayerId { get; set; }

        public virtual User RedPlayer { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        [MinLength(4), MaxLength(4)]
        public string BluePlayerDigits { get; set; }

        [MinLength(4), MaxLength(4)]
        public string RedPlayerDigits { get; set; }

        public virtual ICollection<Guess> BluePlayerGuesses
        {
            get { return this.bluePlayerGuesses; }
            set { this.bluePlayerGuesses = value; }
        }

        public virtual ICollection<Guess> RedPlayerGuesses
        {
            get { return this.redPlayerGuesses; }
            set { this.redPlayerGuesses = value; }
        }
    }
}