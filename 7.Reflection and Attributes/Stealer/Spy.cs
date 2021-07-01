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
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

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

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            var objectType = Type.GetType(className);

            var hackerInstance = Activator.CreateInstance(objectType, null);

            var fields = objectType
                .GetFields(BindingFlags.Instance | BindingFlags.Public);

            var publicSetters = objectType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            var privateGetters = objectType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var fieldInfo in fields)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }

            foreach (var setter in privateGetters.Where(s => s.Name.StartsWith("get")))
            {
                sb.AppendLine($"{setter.Name} have to be public!");
            }

            foreach (var setter in publicSetters.Where(s => s.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }

            return sb.ToString();
        }
    }
}