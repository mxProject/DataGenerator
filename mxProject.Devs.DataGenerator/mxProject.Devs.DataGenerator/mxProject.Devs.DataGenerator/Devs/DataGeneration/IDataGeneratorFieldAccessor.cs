using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    internal interface IDataGeneratorFieldAccessor
    {
        string FieldName { get; }

        Type ValueType { get; }

        int Index { get; }

        object? GetValue();

        object? GetRawValue();

        bool IsNullValue();

        ValueTask InitializeAsync(int generationCount);

        bool GenerateNext();

        void Reset();
    }

}
