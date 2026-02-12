using StationMeteo.Metier;
using System.Text.RegularExpressions;
namespace StationMeteo.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CapteurMeteo capteur1 = new CapteurMeteo("Capteur_Nord", 12.5, 45.2);
            }
            catch (Exception ex)
            {
                throw;
            }

            try
            {
                CapteurMeteo capteur2 = new CapteurMeteo("Capteur123");
            }
            catch (Exception ex)
            {
                throw;
            }

            try
            {
                CapteurMeteo capteur3 = new CapteurMeteo("Capteur_Sud", 12.5, -10);
            }
            catch (Exception ex)
            {
                throw;
            }

            Console.WriteLine("Nom: Capteur_Nord  Température: " + 12.5 + " Humidité: " + 45.2);
        }
    }
}
