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
using System.IO;
using System.Text.RegularExpressions;

namespace Statica
{
    public static class Utils
    {
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

            // Convert culture specific characters
            slug = slug
                .Replace("å", "a")
                .Replace("ä", "a")
                .Replace("á", "a")
                .Replace("à", "a")
                .Replace("ö", "o")
                .Replace("ó", "o")
                .Replace("ò", "o")
                .Replace("é", "e")
                .Replace("è", "e")
                .Replace("í", "i")
                .Replace("ì", "i");

            // Remove special characters
            slug = Regex.Replace(slug, @"[^a-z0-9-/ ]", "").Replace("--", "-");

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