using Modelo;
using Persistencia.DAL;
using System.Linq;

namespace Servico
{
    public class AlunoServico
    {
        private AlunoDAL alunoDAL = new AlunoDAL();

        public IQueryable<Aluno> listarAlunos(int? turmaId = null)
        {
            return alunoDAL.listarAlunos(turmaId);
        }

        public IQueryable<Aluno> listarAlunosSemTurma()
        {
            return alunoDAL.listarAlunosSemTurma();
        }

        public Aluno obterAluno(int? id)
        {
            return alunoDAL.obterAluno(id);
        }

        public void inserirAluno(Aluno aluno)
        {
            alunoDAL.inserirAluno(aluno);
        }

        public void editarAluno(Aluno aluno)
        {
            alunoDAL.editarAluno(aluno);
        }

        public void removerAluno(Aluno aluno)
        {
            alunoDAL.removerAluno(aluno);
        }
    }
}
