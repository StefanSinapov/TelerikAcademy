using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BugLogger.DataLayer
{
    public class Bug
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Text { get; set; }
        public DateTime? LogDate { get; set; }
    }
}
