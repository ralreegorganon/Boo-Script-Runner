using System;
using System.Reflection;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.IO;
using Boo.Lang.Compiler.Pipelines;

namespace RG
{
    public class BooScriptRunner
    {
        private string errors;
        public string Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        public void Run(string text)
        {
            BooCompiler compiler = new BooCompiler();
            compiler.Parameters.Ducky = true;
            compiler.Parameters.Pipeline = new CompileToMemory();
            compiler.Parameters.Input.Add(new StringInput("Script", text));

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                compiler.Parameters.References.Add(assembly);
            }

            CompilerContext context = compiler.Run();

            if (context.GeneratedAssembly == null)
            {
                if (context.Errors.Count > 0)
                {
                    errors = context.Errors.ToString(true);
                }
                return;
            }

            try
            {
                Type[] types = context.GeneratedAssembly.GetTypes();
                Type scriptModule = types[types.Length - 1];
                MethodInfo mainEntry = scriptModule.Assembly.EntryPoint;
                mainEntry.Invoke(null, new object[mainEntry.GetParameters().Length]);
            }
            catch (Exception ex)
            {
                errors = ex.Message;
            }
        }
    }
}
