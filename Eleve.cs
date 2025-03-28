using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; } 
        public List<Note> notes { get; private set; }

        private const int maxNotes = 200;

        public Eleve(string p, string n)
        {
            prenom = p;
            nom = n;
            notes = new List<Note>();
        }

        public void ajouterNote(Note n)
        {
            if (notes.Count >= maxNotes)
            {
                throw new InvalidOperationException(
                    $"Nombre limite de notes pour un eleve atteint ({maxNotes}).\n");
            }
            notes.Add(n);
        }

        public float moyenneMatiere(int m)
        {
            var notesMatiere = notes.Where(n => n.matiere == m).Select(n => n.note);
            return notesMatiere.DefaultIfEmpty(0).Average();

        }

        public float moyenneGeneral()
        {
            var notesMatieres =  notes.GroupBy(n => n.matiere)
                                     .Select(g => moyenneMatiere(g.Key))
                                     .ToList();
            return notesMatieres.DefaultIfEmpty(0).Average();
        }
    }
}