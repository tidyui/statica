/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using Piranha.Extend;

namespace Statica
{
    public class Module : IModule
    {
        /// <summary>
        /// Gets the Author
        /// </summary>
        public string Author => "Håkan Edling";

        /// <summary>
        /// Gets the Name
        /// </summary>
        public string Name => "TidyUI.Statica";

        /// <summary>
        /// Gets the Version
        /// </summary>
        public string Version => Piranha.Utils.GetAssemblyVersion(GetType().Assembly);

        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description => "Module for serving static Markdown files as a page structure.";

        /// <summary>
        /// Gets the package url.
        /// </summary>
        public string PackageUrl => "https://www.nuget.org/packages/Statica";

        /// <summary>
        /// Gets the icon url.
        /// </summary>
        public string IconUrl => "http://piranhacms.org/assets/icon-statica.png";

        /// <summary>
        /// Initializes the module.
        /// </summary>
        public void Init()
        {
        }
    }
}