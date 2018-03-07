using Escola.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escola.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("IdentityDB")
        {
        }

        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(new IdentityDbInit());
        }

        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }
      
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
    {

    }
}