/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Statica.Models;

namespace Statica.Services
{
    public class PageService : IPageService
    {
        /// The base path for the page structure.
        private readonly string _dataPath = "wwwroot/data";

        /// The current page structure.
        private PageStructure _structure = null;

        /// Mutex for initialization.
        private object mutex = new object();

        /// <summary>
        /// Gets the content for the page with the given slug.
        /// </summary>
        /// <param name="slug">The slug</param>
        /// <returns>The content</returns>
        public async Task<string> GetPageContentAsync(string slug)
        {
            if (PageStructure.Routes.TryGetValue(slug, out var page))
            {
                var file = new FileInfo(page.Path);

                using (var sr = new StreamReader(file.OpenRead()))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            throw new FileNotFoundException();
        }

        /// <summary>
        /// Gets the current page structure.
        /// </summary>
        public PageStructure PageStructure
        {
            get {
                // Check if the map has already been loaded
                if (_structure == null)
                {
                    // Lock for thread safety
                    lock (mutex)
                    {
                        if (_structure == null)
                        {
                            // Get the static map
                            var structure = new PageStructure();
                            structure.Items = GetStructureItemsRecursive(structure, _dataPath);

                            _structure = structure;
                        }
                    }
                }
                return _structure;
            }
        }

        /// <summary>
        /// Gets the page structure.
        /// </summary>
        /// <param name="sitemap"></param>
        /// <param name="path"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        private IList<PageStructureItem> GetStructureItemsRecursive(PageStructure structure, string path, string prefix = "")
        {
            var items = new List<PageStructureItem>();

            foreach (var info in new DirectoryInfo(path).GetFileSystemInfos().OrderBy(f => f.Name))
            {
                if (info.Name != "Index.md")
                {
                    var item = new PageStructureItem
                    {
                        Title = Utils.GenerateTitle(info),
                        Slug = prefix + Utils.GenerateSlug(info),
                        Path = info.FullName
                    };

                    // Check if this is a directory
                    if (info is DirectoryInfo dir)
                    {
                        // Get the subitems
                        item.Items = GetStructureItemsRecursive(structure, dir.FullName, $"{item.Slug}/");

                        // Check if the directory has an index file
                        var index = dir.GetFiles("Index.md").FirstOrDefault();
                        if (index != null)
                        {
                            item.Path = index.FullName;
                        }
                        else if (item.Items.Count > 0)
                        {
                            item.Path = null;
                            item.Redirect = item.Items[0].Slug;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    structure.Routes[item.Slug] = item;
                    items.Add(item);
                }
            }
            return items;
        }
    }
}