using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTracking.Models
{
    public class Bug
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        public string ReproductionSteps { get; set; }

        public string ExpectedResult { get; set; }

        public string ActualResult { get; set; }

        public int BugStatusId { get; set; }

        public dic_BugStatuses BugStatus { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}