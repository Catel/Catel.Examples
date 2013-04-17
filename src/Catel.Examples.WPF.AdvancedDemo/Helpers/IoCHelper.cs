namespace Catel.Examples.AdvancedDemo
{
    using System.ComponentModel.Composition.Hosting;
    using Microsoft.Practices.Unity;

    internal static class IoCHelper
    {
        /// <summary>
        /// Gets or sets the unity container.
        /// </summary>
        /// <value>The unity container.</value>
        public static UnityContainer UnityContainer { get; set; }

        /// <summary>
        /// Gets or sets the mef container.
        /// </summary>
        /// <value>The mef container.</value>
        public static CompositionContainer MefContainer { get; set; }
    }
}
