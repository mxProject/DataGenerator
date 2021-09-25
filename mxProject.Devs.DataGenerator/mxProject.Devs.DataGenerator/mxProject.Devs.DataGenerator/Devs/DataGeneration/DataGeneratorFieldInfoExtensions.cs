using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    internal static class DataGeneratorFieldInfoExtensions
    {

        internal static DataGeneratorFieldInfo ToDataGeneratorFieldInfo(this (string fieldName, Type valueType) fieldInfo)
        {
            return new DataGeneratorFieldInfo(fieldInfo.fieldName, fieldInfo.valueType);
        }

        internal static IDataGeneratorFieldInfo[] ToDataGeneratorFieldInfo(this (string fieldName, Type valueType)[] fieldInfos)
        {
            IDataGeneratorFieldInfo[] fields = new IDataGeneratorFieldInfo[fieldInfos.Length];

            for (int i = 0; i < fields.Length; ++i)
            {
                fields[i] = fieldInfos[i].ToDataGeneratorFieldInfo();
            }

            return fields;
        }

    }

}
