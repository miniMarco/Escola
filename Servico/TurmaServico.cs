using Modelo;
using Persistencia.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Servico
{
    public class TurmaServico
    {
        TurmaDAL turmaDAL = new TurmaDAL();

        public IQueryable<Turma> listarTurmas()
        {
            return turmaDAL.listarTurmas();
        }

        public Turma obterTurma(int? id)
        {
            return turmaDAL.obterTurma(id);
        }

        public void salvarTurma(Turma turma)
        {
            turmaDAL.salvarTurma(turma);
        }
        
        public void removerTurma(Turma turma)
        {
            turmaDAL.removerTurma(turma);
        }
    }
}
