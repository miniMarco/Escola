using Modelo;
using Persistencia.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL
{
    public class DisciplinaDAL
    {
        private EFContext context = EFContext.getInstance();

        public Disciplina obterDisciplina(int? id)
        {
            return context.Disciplinas.Find(id);
        }

        public List<Disciplina> listarDisciplinas()
        {
            return context.Disciplinas.ToList();
        }

        public void inserirDisciplina(Disciplina disciplina)
        {
            context.Disciplinas.Add(disciplina);
            context.SaveChanges();
        }

        public void editarDisciplina(Disciplina disciplina)
        {
            context.Entry(disciplina).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void removerDisciplina(Disciplina disciplina)
        {
            context.Disciplinas.Remove(disciplina);
            context.SaveChanges();
        }
    }
}
