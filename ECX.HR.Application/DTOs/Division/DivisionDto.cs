﻿using ECX.HR.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.DTOs.Division
{
    public class DivisionDto : BaseDtos
    {
        public int PId { get; set; }
        public Guid DivisionId { get; set; }
      
        public Guid DepartmentId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
