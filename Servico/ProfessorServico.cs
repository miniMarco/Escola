using Modelo;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class ProfessorServico
    {
        ProfessorDAL professorDAL = new ProfessorDAL();

        public IQueryable<Professor> listarProfessores()
        {
            return professorDAL.listarProfessores();
        }

        public void inserirProfessor(Professor professor)
        {
            professorDAL.inserirProfessor(professor);
        }

        public void removerProfessor(Professor professor)
        {
            professorDAL.removerProfessor(professor);
        }

        public Professor obterProfessor(int? id)
        {
            return professorDAL.obterProfessor(id);
        }
    }
}
