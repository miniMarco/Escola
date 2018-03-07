using Escola.Models;
using Modelo;
using Servico;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class AlunosController : Controller
    {
        private AlunoServico alunoServico = new AlunoServico();
        private DisciplinaServico disciplinaServico = new DisciplinaServico();
        private TurmaServico turmaServico = new TurmaServico();

        private void populateViewBag(Aluno aluno = null)
        {
            if (aluno == null)
            {
                ViewBag.TurmaId = new SelectList(turmaServico.listarTurmas(), "TurmaId", "Descricao");
                ViewBag.DisciplinaId = new SelectList(disciplinaServico.listarDisciplinas(), "DisciplinaId", "Descricao");
            }
            else
            {
                ViewBag.TurmaId = new SelectList(turmaServico.listarTurmas(), "TurmaId", "Descricao", aluno.TurmaId);
                ViewBag.DisciplinaId = new SelectList(disciplinaServico.listarDisciplinas(), "DisciplinaId", "Descricao", aluno.DisciplinaId);
            }
        }
        public ActionResult Index()
        {
            return View(alunoServico.listarAlunos());
        }
        public ActionResult Create()
        {
            populateViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Disciplina disciplina = disciplinaServico.obterDisciplina(aluno.DisciplinaId);

                    if (disciplina != null)
                        aluno.Disciplinas.Add(disciplina);

                    alunoServico.inserirAluno(aluno);

                    return RedirectToAction("Index");
                }
                catch
                {
                    populateViewBag();
                    return View(aluno);
                }
            }
            else
            {
                populateViewBag();
                return View(aluno);
            }
        }
        public ActionResult Edit(int? id)
        {
            Aluno aluno = alunoServico.obterAluno(id);
            populateViewBag(aluno);
            return View(aluno);
        }
        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    alunoServico.editarAluno(aluno);
                    return RedirectToAction("Index");
                }
                catch
                {
                    populateViewBag();
                    return View(aluno);
                }
            }
            else
            {
                populateViewBag();
                return View(aluno);
            }

        }
        public ActionResult Delete(int? id)
        {
            Aluno aluno = alunoServico.obterAluno(id);
            populateViewBag(aluno);
            return View(aluno);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Aluno aluno = alunoServico.obterAluno(id);
            try
            {
                alunoServico.removerAluno(aluno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(aluno);
            }
        }
        public ActionResult LancarNotas()
        {
            return View(turmaServico.listarTurmas());
        }
        public ActionResult InserirNota(int id)
        {
            AlunoViewModel alunovm = new AlunoViewModel();
            Aluno aluno = alunoServico.obterAluno(id);
            alunovm.AlunoId = aluno.AlunoId;
            alunovm.Disciplinas = (List<Disciplina>)aluno.Disciplinas;
            alunovm.NomeAluno = aluno.Nome;
            alunovm.TurmaId = aluno.TurmaId.Value;
            alunovm.Nota = aluno.Notas.Where(item => item.Ano == 2017).FirstOrDefault();
            alunovm.DisciplinaId = alunovm.Nota.DisciplinaId;
            
            if (alunovm.Nota == null)
                alunovm.Nota = new Nota();
            return View(alunovm);
        }
        [HttpPost]
        public ActionResult InserirNota(AlunoViewModel alunovm)
        {
            Aluno aluno = alunoServico.obterAluno(alunovm.AlunoId);
            if (aluno.Notas.Count == 0)
                aluno.Notas.Add(alunovm.Nota);
            else
            {
                Nota nota = aluno.Notas.Where(item => item.NotaId == alunovm.Nota.NotaId).First();
                nota.Nota1 = alunovm.Nota.Nota1;
                nota.Nota2 = alunovm.Nota.Nota2;
                nota.Nota4 = alunovm.Nota.Nota4;
                nota.Nota5 = alunovm.Nota.Nota5;

            }
            //context.SaveChanges();
            return View(alunovm);
        }
    }
}