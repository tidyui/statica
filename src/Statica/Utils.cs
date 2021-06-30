/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Statica
{
    public static class Utils
    {
        /// <summary>
        /// Register provider for ISO-8859-8 encoding
        /// </summary>
        static Utils() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        /// <summary>
        /// Generates a title for the given filesystem info.
        /// </summary>
        /// <param name="info">The filesystem info</param>
        /// <returns>The title</returns>
        public static string GenerateTitle(FileSystemInfo info)
        {
            var str = info.Name.Substring(3);

            if (info is FileInfo)
            {
                str = str.Replace(((FileInfo)info).Extension, "");
            }
            return str;
        }

        /// <summary>
        /// Generates a slug for the given filesystem info.
        /// </summary>
        /// <param name="info">The filesystem info</param>
        /// <returns>The slug</returns>
        public static string GenerateSlug(FileSystemInfo info)
        {
            var str = GenerateTitle(info);

            // Trim & make lower case
            var slug = str.Trim().ToLower();

            // "Latinize" culture-specific characters
            var tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(slug);
            slug = Encoding.UTF8.GetString(tempBytes);

            // Remove special characters
            slug = Regex.Replace(slug, @"[^a-z0-9-/ ]", "");

            // Remove whitespaces
            slug = Regex.Replace(slug.Replace("-", " "), @"\s+", " ").Replace(" ", "-");

            // Remove slashes
            slug = slug.Replace("/", "-");

            // Remove multiple dashes
            slug = Regex.Replace(slug, @"[-]+", "-");

            // Remove leading & trailing dashes
            if (slug.EndsWith("-"))
                slug = slug.Substring(0, slug.LastIndexOf("-"));
            if (slug.StartsWith("-"))
                slug = slug.Substring(Math.Min(slug.IndexOf("-") + 1, slug.Length));
            return slug;
        }
    }
}