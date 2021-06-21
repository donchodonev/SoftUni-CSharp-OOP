using Military.Contracts;
using System;

namespace Military.Models
{
    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; }

        public string State
        {
            get => state;

            set 
            {
                if (value == "inProgress" || value == "Finished")
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void CompleteMission(Mission mission)
        {
            mission.State = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
