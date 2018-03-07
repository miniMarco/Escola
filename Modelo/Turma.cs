using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Turma
    {
        public Turma()
        {
            Professores = new List<Professor>();
            Alunos = new List<Aluno>();
        }
        public int TurmaId { get; set; }
        public string Descricao { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        public List<int> ProfessorId { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }

        public virtual List<int> DisciplinasId { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}