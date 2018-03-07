using Modelo;
using Persistencia.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL
{
    public class AlunoDAL
    {
        private EFContext context = EFContext.getInstance();

        public IQueryable<Aluno> listarAlunos(int? turmaId = null)
        {
            if (turmaId == null)
                return context.Alunos;
            List<Aluno> asd = context.Alunos.Where(aluno => aluno.TurmaId != turmaId).ToList();
            return context.Alunos.Where(aluno => aluno.TurmaId == turmaId);
        }
        public IQueryable<Aluno> listarAlunosSemTurma()
        {
            return context.Alunos.Where(aluno => aluno.TurmaId == null);
        }
        public  void inserirAluno(Aluno aluno)
        {
            context.Alunos.Add(aluno);
            context.SaveChanges();
        }

        public Aluno obterAluno(int? id)
        {
            return context.Alunos.Find(id);
        }

        public void editarAluno(Aluno aluno)
        {
            context.Entry(aluno).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void removerAluno(Aluno aluno)
        {
            context.Alunos.Remove(aluno);
            context.SaveChanges();
        }
    }
}
