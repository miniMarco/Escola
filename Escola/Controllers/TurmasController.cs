using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class TurmasController : Controller
    {
        TurmaServico turmaServico = new TurmaServico();
        DisciplinaServico disciplinaServico = new DisciplinaServico();
        AlunoServico alunoServico = new AlunoServico();

        private void salvarTurma(Turma turma)
        {
            turmaServico.salvarTurma(turma);
        }
        private Turma obterTurma(int? id)
        {
            return turmaServico.obterTurma(id);
        }
        private void removerTurma(Turma turma)
        {
            turmaServico.removerTurma(turma);
        }
        private List<Turma> listarTurmas()
        {
            return turmaServico.listarTurmas().ToList();
        }
        private IQueryable<Aluno> listarAlunosSemTurma()
        {
            return alunoServico.listarAlunosSemTurma();
        }
        private Aluno obterAluno(int id)
        {
            return alunoServico.obterAluno(id);
        }

        public ActionResult Index()
        {
            return View(listarTurmas());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Turma turma)
        {
            turma.Disciplinas = new List<Disciplina>();
            try
            {
                foreach (Disciplina d in disciplinaServico.listarDisciplinas())
                    turma.Disciplinas.Add(d);

                salvarTurma(turma);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(turma);
            }
        }
        public ActionResult Edit(int? id)
        {
            return View(obterTurma(id));
        }

        [HttpPost]
        public ActionResult Edit(Turma turma)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    salvarTurma(turma);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(turma);
                }
            }
            else
            {
                return View(turma);
            }
        }
        public ActionResult Delete(int id)
        {
            return View(obterTurma(id));
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Turma turma = obterTurma(id);
            try
            {
                removerTurma(turma);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(turma);
            }
        }
        
        /************************************/

        public ActionResult Pesquisa()
        {
            return View(listarTurmas());
        }

        public ActionResult AdicionarAluno(int id)
        {
            Turma turma = obterTurma(id);
            List<Aluno> alunos = listarAlunosSemTurma().ToList();

            if (alunos != null && alunos.Count > 0)
            {
                ViewBag.listaAlunos = new SelectList(listarAlunosSemTurma(), "AlunoId", "Nome");
            }
            return View(turma);
        }

        [HttpPost]
        public ActionResult AdicionarAluno(Turma turma, int listaAlunos)
        {
            Turma t = obterTurma(turma.TurmaId);
            Aluno aluno = obterAluno(listaAlunos);
            try
            {
                t.Alunos.Add(aluno);
                salvarTurma(t);
                return RedirectToAction("AdicionarAluno");

            }
            catch (Exception e)
            {
                return View(turma);
            }

        }
    }
}