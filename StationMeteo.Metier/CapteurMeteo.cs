namespace StationMeteo.Metier
{
    /// <summary>
    /// Classe créant un capteur meteo
    /// </summary>
    public class CapteurMeteo
    {
        private string _nom;
        private int _temperature;
        private int _humidite;

        public CapteurMeteo(string nom)
        {
            Nom = nom;
        }

        public CapteurMeteo(string nom, int temprature, int humidite)
        {
            Nom = nom;
            Temperature = temprature;
            Humidite = humidite;
        }

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
                    throw new ArgumentException("Le nom est null ou vide");

                _nom = value; 
            } 
        }

        public int Temperature 
        { 
            get => _temperature;
            private set 
            { 
                if (_temperature < -60)
                    _temperature = -60;

                if (_temperature > 60) 
                    _temperature = 60;

                _temperature = value; 
            }
        }

        public int Humidite 
        { 
            get => _humidite;
            private set 
            {
                if (_humidite < 0)
                    throw new ArgumentOutOfRangeException("Le pourcentage d'humidité est en-dessous de zéro");

                if (_humidite > 100)
                    throw new ArgumentOutOfRangeException("Le pourcentage d'humidité est au-dessus de cent");

                _humidite = value; 
            }
        }
    }
}
