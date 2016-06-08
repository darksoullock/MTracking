using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTracking.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual int? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual int? StatusId { get; set; }

        public virtual dic_Statuses Status { get; set; }

        public string Picture { get; set; }

        public virtual int? CountryId { get; set; }

        public virtual dic_Countries Country { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<Project> OwnedProjects { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Bug> AssignedBugs { get; set; }

        public string Info { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}