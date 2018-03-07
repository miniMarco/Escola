using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Disciplina
    {
        public Disciplina()
        {
            //TurmasId = new List<int>();
        }
        public int DisciplinaId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
        public virtual ICollection<Nota> Notas { get; set; }
        
        //public List<int> TurmasId { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}