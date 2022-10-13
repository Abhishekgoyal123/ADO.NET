using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class ExployeeSkill
    {
        public int EmpNo { get; set; }
        public int ProjectId { get; set; }
        public int Experience { get; set; }
        public string Skills { get; set; } = null!;
    }
}
