using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTracking.Models
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual int BugId { get; set; }

        public virtual Bug Bug { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}