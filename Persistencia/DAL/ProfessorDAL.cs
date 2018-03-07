using Modelo;
using Persistencia.Context;
using System;
using System.Linq;

namespace Persistencia.DAL
{
    public class ProfessorDAL
    {
        private EFContext context = EFContext.getInstance();

        public IQueryable<Professor> listarProfessores()
        {
            return context.Professores;
        }

        public void inserirProfessor(Professor professor)
        {
            context.Professores.Add(professor);
            context.SaveChanges();
        }

        public Professor obterProfessor(int? id)
        {
            return context.Professores.Find(id);
        }

        public void removerProfessor(Professor professor)
        {
            context.Professores.Remove(professor);
            context.SaveChanges();
        }
    }
}
