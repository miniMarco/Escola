using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }

        public int? TurmaId { get; set; }
        public Turma Turma { get; set; }

        public virtual ICollection<Nota> Notas { get; set; }


        public int DisciplinaId { get; set; }
        //public List<int> DisciplinasId { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }

        public Aluno()
        {
            Disciplinas = new List<Disciplina>();
        }
    }
}