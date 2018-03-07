using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Professor
    {
        public Professor()
        {
            Turmas = new List<Turma>();
        }
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public List<int> TurmaId { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}