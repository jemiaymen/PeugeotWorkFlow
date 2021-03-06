﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeugeotWorkFlow.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string Login { get; set; }
        public string Address { get; set; }
        public DateTime Datenaiss { get; set; }
        public string Tel { get; set; }
        public string SignatureUser { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }


        public virtual Department Department { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.Fournisseur> Fournisseurs { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.CategoryInFournisseur> CategoryInFournisseur { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.Achat> Achats { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.Avis> Avis { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.AchatInNotification> AchatInNotification { get; set; }

        public System.Data.Entity.DbSet<PeugeotWorkFlow.Models.AchaFournisseur> AchaFournisseurs { get; set; }

    }
}