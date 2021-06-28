using P01.Stream_Progress.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Music : IProgressable
    {
        private string album;
        private string artist;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int BytesSent { get; set; }
        public int Length { get; set; }
    }
}