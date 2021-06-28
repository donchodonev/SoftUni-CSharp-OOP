using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress.Interfaces
{
    public interface IProgressable
    {
        public int BytesSent { get; set; }
        public int Length { get; set; }
    }
}