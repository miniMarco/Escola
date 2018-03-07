using Modelo;
using Persistencia.Migrations;
using System.Data.Entity;

namespace Persistencia.Context
{
    public class EFContext : DbContext
    {
        private static EFContext instance;
        private EFContext() : base("base_escola")
        {
            Database.SetInitializer<EFContext>(new System.Data.Entity.DropCreateDatabaseIfModelChanges<EFContext>());
            //Database.SetInitializer<EFContext>(new System.Data.Entity.MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        public static EFContext getInstance()
        {
            if (instance == null)
                instance = new EFContext();

            return instance;
        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
    }
}