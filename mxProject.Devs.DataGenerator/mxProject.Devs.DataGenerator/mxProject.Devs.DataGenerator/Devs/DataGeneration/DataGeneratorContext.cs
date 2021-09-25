using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using mxProject.Devs.DataGeneration.Configuration.Json;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Context that holds the state of the data generation process.
    /// </summary>
    public class DataGeneratorContext
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldFactory">The field factory.</param>
        /// <param name="randomGenerator">The random value generation logic.</param>
        /// <param name="stringConverter">The string converter.</param>
        /// <param name="enumerableFactory">The enumerable factory.</param>
        /// <param name="cSharpScriptGlobalObject">The object to use as a global variable in CSharpScript.</param>
        public DataGeneratorContext(DataGeneratorFieldFactory? fieldFactory = null, IRandomGenerator? randomGenerator = null, IStringConverter? stringConverter = null, EnumerableFactory? enumerableFactory = null, object? cSharpScriptGlobalObject = null)
        {
            RandomGenerator = randomGenerator ?? DefaultRandomGenerator.Instance;
            StringConverter = stringConverter ?? DefaultStringConverter.Instance;
            EnumerableFactory = enumerableFactory ?? new EnumerableFactory(RandomGenerator);
            FieldFactory = fieldFactory ?? new DataGeneratorFieldFactory(EnumerableFactory);
            CSharpScriptGlobalObject = cSharpScriptGlobalObject;
        }

        /// <summary>
        /// Gets the field factory.
        /// </summary>
        public DataGeneratorFieldFactory FieldFactory { get; }

        /// <summary>
        /// Gets the random value generation logic.
        /// </summary>
        public IRandomGenerator RandomGenerator { get; }

        /// <summary>
        /// Gets the string converter.
        /// </summary>
        public IStringConverter StringConverter { get; }

        /// <summary>
        /// Gets the enumerable factory.
        /// </summary>
        public EnumerableFactory EnumerableFactory { get; }

        /// <summary>
        /// Gets the object to use as a global variable in CSharpScript.
        /// </summary>
        public object? CSharpScriptGlobalObject { get; }

    }

}
