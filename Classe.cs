using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        private const int maxEleves = 30;
        private const int maxMatieres = 10;

        public Classe(string nc)
        {
            nomClasse = nc;
            eleves = new List<Eleve>();
            matieres = new List<string>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count >= maxEleves)
            {
                throw new InvalidOperationException(
                    $"Nombre maximum d'eleves atteint pour une classe ({maxEleves})\n");
            }
            eleves.Add(new Eleve(prenom, nom));
        }

        public void ajouterMatiere(string matiere)
        {   
            if (matieres.Count >= maxMatieres)
            {
                throw new InvalidOperationException(
                    $"Nombre maximum de matieres atteint pour une classe ({maxMatieres})\n");
            }
            matieres.Add(matiere);
        }

        public float moyenneMatiere(int matiere)
        {
            var moyMatiere = eleves.Select(e => e.moyenneMatiere(matiere));
            return moyMatiere.DefaultIfEmpty(0).Average();
        }

        public float moyenneGeneral()
        {
            var moyMatieres = eleves.Select(e => e.moyenneGeneral());
            return moyMatieres.DefaultIfEmpty(0).Average();
        }

    }

}