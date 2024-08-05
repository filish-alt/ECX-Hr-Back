﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Response
{
    public class BaseCommandResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get;set; }
        public List<string> Errors { get; set; }
        public string Status { get; set; }


    }
}
