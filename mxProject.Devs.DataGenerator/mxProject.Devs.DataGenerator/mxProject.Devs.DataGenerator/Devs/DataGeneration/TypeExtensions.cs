using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="Type"/>.
    /// </summary>
    internal static class TypeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static Type GetUnderlayValueTypeOrSelf(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return type.GetGenericArguments()[0];
            }
            else
            {
                return type;
            }
        }

        internal static Type ToNullableValueTypeOrSelf(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return type;
            }
            else if (type.IsValueType)
            {
                return typeof(Nullable<>).MakeGenericType(type);
            }
            else
            {
                return type;
            }
        }

        #region generic method

        internal static MethodInfo GetGenericMethod(this Type type, string name)
        {
            var method = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            if (method == null)
            {
                throw new NullReferenceException($"The specified method cannot be found. method={type.Name}.{name}");
            }

            return method;
        }

        internal static MethodInfo GetGenericMethod(this Type type, string name, params Type[] argumentTypes)
        {
            var method = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance, null, argumentTypes, null);

            if (method == null)
            {
                throw new NullReferenceException($"The specified method cannot be found. method={type.Name}.{name}");
            }

            return method;
        }

        internal static TResult InvokeGenericMethod<TResult>(this object obj, MethodInfo method, Type[] genericTypes, params object[] arguments)
        {
            try
            {
                return (TResult)method.MakeGenericMethod(genericTypes).Invoke(obj, arguments);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to invoke the specified method. method={obj?.GetType().Name}.{method.Name}", ex);
            }
        }

        internal static object? InvokeGenericMethod(this object obj, MethodInfo method, Type[] genericTypes, params object[] arguments)
        {
            try
            {
                return method.MakeGenericMethod(genericTypes).Invoke(obj, arguments);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to invoke the specified method. method={obj?.GetType().Name}.{method.Name}", ex);
            }
        }

        internal static TResult InvokeStaticGenericMethod<TResult>(this Type type, MethodInfo method, Type[] genericTypes, params object[] arguments)
        {
            try
            {
                return (TResult)method.MakeGenericMethod(genericTypes).Invoke(null, arguments);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to invoke the specified method. method={type.Name}.{method.Name}", ex);
            }
        }

        internal static object? InvokeStaticGenericMethod(this Type type, MethodInfo method, Type[] genericTypes, params object[] arguments)
        {
            try
            {
                return method.MakeGenericMethod(genericTypes).Invoke(null, arguments);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to invoke the specified method. method={type.Name}.{method.Name}", ex);
            }
        }

        #endregion

    }

}
