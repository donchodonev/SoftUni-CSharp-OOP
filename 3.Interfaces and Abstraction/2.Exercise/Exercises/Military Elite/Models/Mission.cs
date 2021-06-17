using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Mission
    {
        private string state;
        public Mission(string codeName, string state)
        {
            Codename = codeName;
            State = state;
        }
        public string Codename { get; set; }

        private string State
        {
             get => state;
             set 
            {
                if (value == "Finished")
                {
                    state = value;
                }
                else if (value == "inProgress")
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Code Name: {Codename} State: {State}");
            return sb.ToString();
        }
    }
}
