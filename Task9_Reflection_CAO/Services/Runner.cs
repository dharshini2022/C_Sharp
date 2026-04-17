using System;
using System.Linq;
using System.Reflection;
using ReflectionRunner.Attributes;

namespace ReflectionRunner.Services
{
    public class Runner
    {
        public void Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes();

            foreach(var type in types)
            {
                var methods = type.GetMethods()
                                        .Where(m => m.GetCustomAttributes(typeof(RunnableAttribute), false).Any())
                                        .ToList();
                if(!methods.Any())
                    continue;

                object instance = null;

                foreach(var method in methods)
                {
                    if (!method.IsStatic)
                    {
                        instance ??= Activator.CreateInstance(type);
                    }
                    Console.WriteLine($"Executing: {type.Name}.{method.Name}");

                    method.Invoke(instance,null);
                }
            }
        }
    }
}