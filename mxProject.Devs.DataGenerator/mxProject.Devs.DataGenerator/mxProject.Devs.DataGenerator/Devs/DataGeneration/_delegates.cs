using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<object?>> EnumerationCreator(int generateCount);

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<string?>> StringEnumerationCreator(int generateCount);

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T">The type of value to generate.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<T?>> EnumerationCreator<T>(int generateCount)
        where T : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?)>> TupleEnumerationCreator<T1, T2>(int generateCount)
        where T1 : struct
        where T2 : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?, T3?)>> TupleEnumerationCreator<T1, T2, T3>(int generateCount)
        where T1 : struct
        where T2 : struct
        where T3 : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
    /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?, T3?, T4?)>> TupleEnumerationCreator<T1, T2, T3, T4>(int generateCount)
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
    /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
    /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?)>> TupleEnumerationCreator<T1, T2, T3, T4, T5>(int generateCount)
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
    /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
    /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
    /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)>> TupleEnumerationCreator<T1, T2, T3, T4, T5, T6>(int generateCount)
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
    /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
    /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
    /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
    /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>> TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7>(int generateCount)
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
    /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
    /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
    /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
    /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
    /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)>> TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8>(int generateCount)
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct;

    /// <summary>
    /// Indicates a method that generates an enumeration. 
    /// </summary>
    /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
    /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
    /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
    /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
    /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
    /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
    /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
    /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
    /// <typeparam name="T9">The type of object to enumerate in the ninth enumeration.</typeparam>
    /// <param name="generateCount">Number of values to generate.</param>
    /// <returns></returns>
    public delegate ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)>> TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8, T9>(int generateCount)
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
        where T9 : struct;

}
