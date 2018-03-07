using Modelo;
using Servico;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class ProfessoresController : Controller
    {
        TurmaServico turmaServico = new TurmaServico();
        ProfessorServico professorServico = new ProfessorServico();

        private Professor obterProfessor(int? id)
        {
            return professorServico.obterProfessor(id);
        }
        private void removerProfessor(Professor professor)
        {
            professorServico.removerProfessor(professor);
        }

        private void populateDropDown()
        {
            ViewBag.TurmaId = new SelectList(turmaServico.listarTurmas(), "TurmaId", "Descricao");
        }
        public ActionResult Index()
        {
            return View(professorServico.listarProfessores());
        }
        public ActionResult Create()
        {
            populateDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (int id in professor.TurmaId)
                    {
                        Turma turma = turmaServico.obterTurma(id);
                        if (turma != null)
                            professor.Turmas.Add(turma);
                    }
                    professorServico.inserirProfessor(professor);
                    return RedirectToAction("Index");
                }
                catch
                {
                    populateDropDown();
                    return View(professor);
                }
            }
            else
            {
                populateDropDown();
                return View(professor);
            }
        }
        public ActionResult Delete(int? id)
        {
            Professor professor = obterProfessor(id);
            return View(professor);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Professor professor = obterProfessor(id);
            try
            {
                removerProfessor(professor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(professor);
            }
        }
    }
}