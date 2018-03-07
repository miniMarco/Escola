using Modelo;
using Persistencia.Context;
using System.Linq;
using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace Persistencia.DAL
{
    public class TurmaDAL
    {
        private EFContext context = EFContext.getInstance();

        public IQueryable<Turma> listarTurmas()
        {
            return context.Turmas; 
        }

        public Turma obterTurma(int? id)
        {
            return context.Turmas.Find(id);
        }

        public void salvarTurma(Turma turma)
        {
            turma.UltimaAlteracao = DateTime.Now;
            if (turma.TurmaId == 0)
                context.Turmas.Add(turma);
            else
                context.Entry(turma).State = EntityState.Modified;

            context.SaveChanges();
        }
        
        public void removerTurma(Turma turma)
        {
            context.Turmas.Remove(turma);
            context.SaveChanges();
        }
    }
}
