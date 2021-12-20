using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Quizzs
{
    public class QuizTest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Quizz Quizz { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int Score { get; set; }
        public Dictionary<Question, List<Reponse>> UserReponses { get; set; }

        public QuizTest(DateTime date, Quizz quizz, Utilisateur utilisateur, int score)
        {
            Date = date;
            Quizz = quizz;
            Utilisateur = utilisateur;
            Score = score;
            UserReponses = new Dictionary<Question, List<Reponse>>();
        }

        //Méthode qui vérifie la réponse
        public void CheckReponse(Question qst, string choiceStr)
        {
            if (!qst.IsMultiple) // qst à 1 seule réponse
            {
                int choice = Convert.ToInt32(choiceStr);
                if (choice < 1 || choice>qst.Reponses.Count)
                {
                    throw new Exception("Erreur: le choix doit être compris en 1 et " + qst.Reponses.Count);
                }

                //Vérifier si la réponse est correct
                if (qst.Reponses[choice - 1].IsCorrect)
                {
                    Score++;
                }
                UserReponses.Add(qst, new List<Reponse> { qst.Reponses[choice - 1] });
            }
            else //1,3
            {
                string[] choices = choiceStr.Split(',');
                List<Reponse> userRep = new List<Reponse>();

                foreach (var choice in choices)
                {
                    int choix = Convert.ToInt32(choice);
                    if (choix < 1 || choix > qst.Reponses.Count)
                    {
                        throw new Exception("Erreur: le choix doit être compris en 1 et " + qst.Reponses.Count);
                    }

                    if (qst.Reponses[choix - 1].IsCorrect)
                    {
                        Score++;
                    }
                    else
                    {
                        Score--;
                    }
                    userRep.Add(qst.Reponses[choix - 1]);
                }

                UserReponses.Add(qst, userRep);

            }
        }

        public  void SendResult()
        {
            string emailBody = "Bonjour,\n votre score pour le quizz " + Quizz.Sujet + " est de : " + Score;

            MailMessage message = new MailMessage("noreplay@dawn.fr", Utilisateur.Email, "Quiz sujet: " + Quizz.Sujet, emailBody);
            //message.CC.Add("email");

            //Sauvegarder les réponses dans un fichier
            var sw = new StreamWriter(@"c:\monRep\quiz.txt");

            sw.WriteLine("Date: " + Date + " Vos réponses au quiz: " + Quizz.Sujet + ":");

            foreach (var reponses in UserReponses.Values)
            {
                foreach (var rep in reponses)
                {
                    sw.WriteLine(rep.RepText);
                }
            }
            sw.Close();

            //Attaché ce fihcier au mail
            message.Attachments.Add(new Attachment(@"c:\monRep\quiz.txt"));

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("username", "password");
            client.EnableSsl = true;
            client.Send(message);
        }
    }

    }