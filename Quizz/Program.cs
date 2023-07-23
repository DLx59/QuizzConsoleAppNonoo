using Quizz.Data.Models;
using Quizz.Data.Enums;

namespace Quizz
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            while (true)
            {
                var deck = CreateDeck();
                Console.WriteLine("Bienvenue dans le jeu de questions-réponses !");
                Console.WriteLine("Appuyez sur une touche pour commencer...");
                Console.ReadKey();

                foreach (var card in deck)
                {
                    DisplayQuestion(card.Question);
                    WaitingForAnswer(TypeCard.Question);
                    DisplayAnswer(card.Answer);
                    WaitingForAnswer(TypeCard.Answer);
                }

                Console.WriteLine("Félicitations, vous avez terminé toutes les cartes !");
                Console.WriteLine("Appuyez sur une touche pour recommencer ou appuyez sur 'Q' pour quitter.");

                var key = Console.ReadKey();
                if (key.KeyChar.ToString().ToUpper() == "Q")
                    break;

                Console.Clear();
            }
        }

        private static List<Card> CreateDeck()
        {
            var deck = new List<Card>
            {
                new()
                {
                    Question = "Quelle est la capitale de l'Australie ?",
                    Answer = "La capitale de l'Australie est Canberra."
                },
                new()
                {
                    Question = "Qui a peint la célèbre Mona Lisa ?",
                    Answer = "La célèbre Mona Lisa a été peinte par Leonardo da Vinci."
                },
                new()
                {
                    Question = "Quel est le plus grand océan du monde ?",
                    Answer = "Le plus grand océan du monde est l'océan Pacifique."
                }
            };
            return deck;
        }

        private static void DisplayQuestion(string question)
        {
            Console.Clear();
            Console.WriteLine("Question : " + question);
        }

        private static void WaitingForAnswer(TypeCard typeCard)
        {
            Console.WriteLine((typeCard == TypeCard.Question)
                ? "Appuyez sur une touche pour afficher la réponse..."
                : "Appuyez sur une touche pour afficher une autre question...");
            Console.ReadKey();
        }

        private static void DisplayAnswer(string answer)
        {
            Console.WriteLine("Réponse : " + answer);
        }
    }
}