using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Nota
    {
        public int NotaId { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public double? Nota1 { get; set; }
        public double? Nota2 { get; set; }
        public double? Nota3 { get; set; }
        public double? Nota4 { get; set; }
        public double? Nota5 { get; set; }
        public double? Nota6 { get; set; }
        public double? Nota7 { get; set; }
        public double? Nota8 { get; set; }
        public double? Nota9 { get; set; }
        public double? Nota10 { get; set; }
        public bool Aprovado { get; set; }
        public int? Ano { get; set; }
    }
}