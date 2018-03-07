using Modelo;
using Servico;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class DisciplinasController : Controller
    {
        private DisciplinaServico disciplinaServico = new DisciplinaServico();
        TurmaServico turmaServico = new TurmaServico();

        public ActionResult Index()
        {
            return View(disciplinaServico.listarDisciplinas());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Disciplina disciplina)
        {
            disciplina.Turmas = new List<Turma>();
            foreach (Turma t in turmaServico.listarTurmas())
            {
                disciplina.Turmas.Add(t);
            }
            disciplinaServico.inserirDisciplina(disciplina);
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Disciplina disciplina = disciplinaServico.obterDisciplina(id);
            return View(disciplina);
        }

        [HttpPost]
        public ActionResult Edit(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                disciplinaServico.editarDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            else
            {
                return View(disciplina);
            }
        }

        public ActionResult Delete(int id)
        {
            Disciplina disciplina = disciplinaServico.obterDisciplina(id);
            return View(disciplina);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Disciplina disciplina = disciplinaServico.obterDisciplina(id);
            try
            {
                disciplinaServico.removerDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(disciplina);
            }
        }


    }
}