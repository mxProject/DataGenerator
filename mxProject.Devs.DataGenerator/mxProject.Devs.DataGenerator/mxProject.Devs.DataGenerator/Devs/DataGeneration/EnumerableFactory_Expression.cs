using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Data;

namespace mxProject.Devs.DataGeneration
{
    partial class EnumerableFactory
    {

        #region arg => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg">The type of value to use as the argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg, TResult)> Expression<TArg, TResult>(IEnumerable<TArg> argumentValues, Func<TArg, TResult> func)
            where TArg : struct
            where TResult : struct
        {
            foreach (var value in argumentValues)
            {
                yield return (value, func(value));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg">The type of value to use as the argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg?, TResult?)> Expression<TArg, TResult>(IEnumerable<TArg?> argumentValues, Func<TArg?, TResult?> func)
            where TArg : struct
            where TResult : struct
        {
            foreach (var value in argumentValues)
            {
                yield return (value, func(value));
            }
        }

        #endregion

        #region (arg1, arg2) => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1, TArg2, TResult)> Expression<TArg1, TArg2, TResult>(IEnumerable<(TArg1, TArg2)> argumentsValues, Func<TArg1, TArg2, TResult> func)
            where TArg1 : struct
            where TArg2 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, func(value.Item1, value.Item2));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1?, TArg2?, TResult?)> Expression<TArg1, TArg2, TResult>(IEnumerable<(TArg1?, TArg2?)> argumentsValues, Func<TArg1?, TArg2?, TResult?> func)
            where TArg1 : struct
            where TArg2 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, func(value.Item1, value.Item2));
            }
        }

        #endregion

        #region (arg1, arg2, arg3) => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1, TArg2, TArg3, TResult)> Expression<TArg1, TArg2, TArg3, TResult>(
            IEnumerable<(TArg1, TArg2, TArg3)> argumentsValues
            , Func<TArg1, TArg2, TArg3, TResult> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, func(value.Item1, value.Item2, value.Item3));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1?, TArg2?, TArg3?, TResult?)> Expression<TArg1, TArg2, TArg3, TResult>(
            IEnumerable<(TArg1?, TArg2?, TArg3?)> argumentsValues
            , Func<TArg1?, TArg2?, TArg3?, TResult?> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, func(value.Item1, value.Item2, value.Item3));
            }
        }

        #endregion

        #region (arg1, arg2, arg3, arg4) => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1, TArg2, TArg3, TArg4, TResult)> Expression<TArg1, TArg2, TArg3, TArg4, TResult>(
            IEnumerable<(TArg1, TArg2, TArg3, TArg4)> argumentsValues
            , Func<TArg1, TArg2, TArg3, TArg4, TResult> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, func(value.Item1, value.Item2, value.Item3, value.Item4));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TResult?)> Expression<TArg1, TArg2, TArg3, TArg4, TResult>(
            IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?)> argumentsValues
            , Func<TArg1?, TArg2?, TArg3?, TArg4?, TResult?> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, func(value.Item1, value.Item2, value.Item3, value.Item4));
            }
        }

        #endregion

        #region (arg1, arg2, arg3, arg4, arg5) => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5, TResult)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
            IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5)> argumentsValues
            , Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TResult?)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
            IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?)> argumentsValues
            , Func<TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TResult?> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5));
            }
        }

        #endregion

        #region (arg1, arg2, arg3, arg4, arg5, arg6) => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of value to use as the sixth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(
            IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5, TArg6)> argumentsValues
            , Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TArg6 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of value to use as the sixth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TResult?)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(
            IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?)> argumentsValues
            , Func<TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TResult?> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TArg6 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6));
            }
        }

        #endregion

        #region (arg1, arg2, arg3, arg4, arg5, arg6, arg7) => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of value to use as the sixth argument.</typeparam>
        /// <typeparam name="TArg7">The type of value to use as the seevnth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(
            IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7)> argumentsValues
            , Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TArg6 : struct
            where TArg7 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of value to use as the sixth argument.</typeparam>
        /// <typeparam name="TArg7">The type of value to use as the seevnth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TArg7?, TResult?)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(
            IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TArg7?)> argumentsValues
            , Func<TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TArg7?, TResult?> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TArg6 : struct
            where TArg7 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7));
            }
        }

        #endregion

        #region (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => result

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of value to use as the sixth argument.</typeparam>
        /// <typeparam name="TArg7">The type of value to use as the seevnth argument.</typeparam>
        /// <typeparam name="TArg8">The type of value to use as the eighth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
            IEnumerable<(TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8)> argumentsValues
            , Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TArg6 : struct
            where TArg7 : struct
            where TArg8 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8));
            }
        }

        /// <summary>
        /// Enumerates the specified values and the return value of the expression.
        /// </summary>
        /// <typeparam name="TArg1">The type of value to use as the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of value to use as the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of value to use as the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of value to use as the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of value to use as the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of value to use as the sixth argument.</typeparam>
        /// <typeparam name="TArg7">The type of value to use as the seevnth argument.</typeparam>
        /// <typeparam name="TArg8">The type of value to use as the eighth argument.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the expression.</typeparam>
        /// <param name="argumentsValues">The values to use as the argument.</param>
        /// <param name="func">The expression.</param>
        /// <returns></returns>
        public IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TArg7?, TArg8?, TResult?)> Expression<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
            IEnumerable<(TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TArg7?, TArg8?)> argumentsValues
            , Func<TArg1?, TArg2?, TArg3?, TArg4?, TArg5?, TArg6?, TArg7?, TArg8?, TResult?> func
            )
            where TArg1 : struct
            where TArg2 : struct
            where TArg3 : struct
            where TArg4 : struct
            where TArg5 : struct
            where TArg6 : struct
            where TArg7 : struct
            where TArg8 : struct
            where TResult : struct
        {
            foreach (var value in argumentsValues)
            {
                yield return (value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8, func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, value.Item8));
            }
        }

        #endregion

    }
}
