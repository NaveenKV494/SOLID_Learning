using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Learning
{


    // SRP: DragonBall class is responsible for managing a character in Dragon Ball
    public class DragonBallCharacter
    {
        public string Name { get; }
        public string Superpower { get; }
        public string Family { get; }
        public int Wins { get; }

        public DragonBallCharacter(string name, string superpower, string family, int win)
        {
            Name = name;
            Superpower = superpower;
            Family = family;
            Wins = win;
        }
    }

    // OCP and LSP: Introducing an interface for moves that can be implemented by different attack types
    public interface IMove
    {
        string Name { get; }
        string Action();
    }

    // ISP: Different types of moves have specific actions
    public class FinishMove : IMove
    {
        public string Name { get; }

        public FinishMove(string name)
        {
            Name = name;
        }

        public string Action() => "Kills";
    }

    public class AttackMove : IMove
    {
        public string Name { get; }

        public AttackMove(string name)
        {
            Name = name;
        }

        public string Action() => "Attacks";
    }

    // DIP: DragonBallCharacter class is not coupled directly to any specific move implementation
    public class DragonBallCharacterMoves
    {
        private readonly List<IMove> moves = new List<IMove>();

        public void AddMove(IMove move)
        {
            moves.Add(move);
        }

        public void DisplayMoves()
        {
            foreach (var move in moves)
            {
                Console.WriteLine($"      {move.Name} - {move.Action()}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var goku = new DragonBallCharacter("Goku", "Ultra Instinct", "Son", 32);
            var vegeta = new DragonBallCharacter("Vegeta", "Super Saiyan God", "Vegeta", 29);

            var gokuMoves = new DragonBallCharacterMoves();
            gokuMoves.AddMove(new FinishMove("Kamehameha"));
            gokuMoves.AddMove(new AttackMove("Instant Hit"));

            var vegetaMoves = new DragonBallCharacterMoves();
            vegetaMoves.AddMove(new FinishMove("Final Flash"));
            vegetaMoves.AddMove(new AttackMove("Flash Beam"));

            Console.WriteLine($"{goku.Name} - {goku.Superpower} - {goku.Family} - Wins: {goku.Wins}");
            gokuMoves.DisplayMoves();

            Console.WriteLine($"{vegeta.Name} - {vegeta.Superpower} - {vegeta.Family} - Wins: {vegeta.Wins}");
            vegetaMoves.DisplayMoves();
        }
    }

}
