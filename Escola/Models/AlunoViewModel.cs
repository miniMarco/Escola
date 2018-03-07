using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escola.Models
{
    public class AlunoViewModel
    {
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public Nota Nota { get; set; }
        public int DisciplinaId { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public int TurmaId { get; set; }
    }
}