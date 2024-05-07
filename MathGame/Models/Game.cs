using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
namespace MathGame.Models
{
    [Table ("game")]
    public class Game
    {
        [PrimaryKey,AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public GameOperataion Type { get; set; }

        public int Score { get; set; }  
        public DateTime DatePlayed { get; set; }
    }
    public enum GameOperataion
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

}
