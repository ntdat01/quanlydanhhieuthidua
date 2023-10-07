﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain
{
    public class ConflictException : Exception
    {
        public int ErrorCode { get; set; }
        public ConflictException() { }
        public ConflictException(int errorCode)
        {
            ErrorCode = errorCode;
        }
        public ConflictException(string message) : base(message) { }
        public ConflictException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
