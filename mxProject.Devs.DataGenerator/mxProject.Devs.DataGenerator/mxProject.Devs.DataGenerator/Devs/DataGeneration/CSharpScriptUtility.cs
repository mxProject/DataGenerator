using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace mxProject.Devs.DataGeneration
{

    internal static class CSharpScriptUtility
    {

        private static readonly ScriptOptions s_ScriptOptions = ScriptOptions.Default.AddReferences(Assembly.GetAssembly(typeof(CSharpScriptUtility)));

        /// <summary>
        /// Creates a selector.
        /// </summary>
        /// <returns>A selector.</returns>
        internal static Task<TFunc> CreateFuncAsync<TFunc>(string expression, DataGeneratorContext context)
        {
            return CSharpScript.EvaluateAsync<TFunc>($"return {expression};", s_ScriptOptions, globals: context.CSharpScriptGlobalObject);
        }

    }

}
