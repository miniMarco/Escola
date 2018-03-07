using Modelo;
using Persistencia.DAL;
using System.Collections.Generic;

namespace Servico
{
    public class DisciplinaServico
    {
        DisciplinaDAL disciplinaDAL = new DisciplinaDAL();

        public Disciplina obterDisciplina(int? id)
        {
            return disciplinaDAL.obterDisciplina(id);
        }

        public List<Disciplina> listarDisciplinas()
        {
            return disciplinaDAL.listarDisciplinas();
        }

        public void inserirDisciplina(Disciplina disciplina)
        {
            disciplinaDAL.inserirDisciplina(disciplina);
        }

        public void editarDisciplina(Disciplina disciplina)
        {
            disciplinaDAL.editarDisciplina(disciplina);
        }

        public void removerDisciplina(Disciplina disciplina)
        {
            disciplinaDAL.removerDisciplina(disciplina);
        }
    }
}
