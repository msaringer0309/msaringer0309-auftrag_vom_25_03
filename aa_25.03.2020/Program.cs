using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aa_25._03._2020
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Game spiel = new Game();

            #region Fragen

            
            Question frage1 = new Question("Wie viel ist 2 + 2?");
            frage1.AddAnswer(new Answer("5"));
            frage1.AddAnswer(new Answer("4", true));
            spiel.AddQuestion(frage1);

            Question frage2 = new Question("Wie viel ist 3 + 3 + 3 x 3?");
            frage2.AddAnswer(new Answer("15",true));
            frage2.AddAnswer(new Answer("27"));
            frage2.AddAnswer(new Answer("30"));
            frage2.AddAnswer(new Answer("14"));
            spiel.AddQuestion(frage2);

            Question frage3 = new Question("Wie viel ist (3 + 3 + 3 ) x 3?");
            frage3.AddAnswer(new Answer("15"));
            frage3.AddAnswer(new Answer("27", true));
            frage3.AddAnswer(new Answer("33"));
            frage3.AddAnswer(new Answer("333"));
            spiel.AddQuestion(frage3);
            #endregion


            

            while (spiel.Status == GameStatus.Active)
            {
               
                var frage = spiel.NextQuestion;
                var antworten = frage.Answers;

                Console.WriteLine(frage.Text);
                int counter = 0;
                foreach (var antwort in antworten)
                {
                    
                    Console.WriteLine( "(" + counter + ")" + " " + antwort.Text);
                    counter++;
                }

                Console.Write("Geben sie die nummer der richtigen Lösung ein: ");
                int eingabe = Convert.ToInt32(Console.ReadLine());

                antworten[eingabe].IsChecked = true;

                spiel.ValidateCurrentQuestion();

            }

            if (spiel.Status == GameStatus.HasFinished)
            {
                Console.WriteLine("Du hast alles richtig super! "); 
            }

            if (spiel.Status == GameStatus.HasLost)
            {
                Console.WriteLine("Du hast verloren! "); 
            }

            if (spiel.Status == GameStatus.Quit)
            {
                Console.WriteLine("Du hast vorzeitig das Spiel verlassen! ");
            }
        }
    }
}
