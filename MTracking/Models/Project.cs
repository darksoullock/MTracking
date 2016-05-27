using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTracking.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }

        public string Description { get; set; }
    }
}