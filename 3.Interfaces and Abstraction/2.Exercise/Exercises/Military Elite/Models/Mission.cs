using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Mission
    {
        private string state;
        public Mission(string codename, string state)
        {
            Codename = codename;
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

        private void CompleteMission()
        {
            state = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {Codename} State: {State}";
        }
    }
}
