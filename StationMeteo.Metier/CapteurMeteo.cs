namespace StationMeteo.Metier
{
    /// <summary>
    /// Classe créant un capteur meteo
    /// </summary>
    public class CapteurMeteo
    {
        private string _nom;
        private double _temperature;
        private double _humidite;

        /// <summary>
        /// constructeur d'un capteur meteo avec uniquement le nom
        /// </summary>
        /// <param name="nom">nom du capteur</param>
        public CapteurMeteo(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// constructeur d'un capteur avec nom, temperature, humidite
        /// </summary>
        /// <param name="nom">nom du capteur</param>
        /// <param name="temprature">température</param>
        /// <param name="humidite">pourcentage d'humidite</param>
        public CapteurMeteo(string nom, double temprature, double humidite)
        {
            Nom = nom;
            Temperature = temprature;
            Humidite = humidite;
        }

        /// <summary>
        /// méthode qui vérifie si le texte contient des chiffres
        /// </summary>
        /// <param name="texte">string</param>
        /// <returns>vrai si le texte contient des string et faux si il n'en contient pas</returns>
        /// <exception cref="ArgumentException">Envoie une exception si le texte est null ou vide</exception>
        private bool ContientDesChiffres(string texte)
        {
            if (string.IsNullOrEmpty(texte))
                throw new ArgumentException("Le texte est null ou ne contient rien");

            bool contientchiffre = false;
            foreach (char c in texte)
            {
                if (char.IsDigit(c))
                {
                    contientchiffre = true;
                }
            }
            return contientchiffre;
        }


        public string Nom 
        { 
            get => _nom;
            private set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Le nom est null ou vide");

                if (ContientDesChiffres(value) == true)
                    throw new ArgumentException("Le nom contient des chiffres");

                _nom = value; 
            } 
        }

        public double Temperature 
        { 
            get => _temperature;
            private set 
            { 
                if (value < -60)
                    _temperature = -60;

                if (value > 60) 
                    _temperature = 60;

                _temperature = value; 
            }
        }

        public double Humidite 
        { 
            get => _humidite;
            private set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Le pourcentage d'humidité est en-dessous de zéro");

                if (value > 100)
                    throw new ArgumentOutOfRangeException("Le pourcentage d'humidité est au-dessus de cent");

                _humidite = value; 
            }
        }
    }
}
