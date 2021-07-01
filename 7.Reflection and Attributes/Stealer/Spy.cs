using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
        {
            Type hacker = Type.GetType(nameOfClass);

            StringBuilder sb = new StringBuilder();

            var hackerInstance = Activator.CreateInstance(hacker, null);

            var fields = hacker
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (var name in namesOfFields)
            {
                foreach (var field in fields.Where(f => f.Name == name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(hackerInstance)}");
                }
            }

            return sb.ToString();
        }
    }
}