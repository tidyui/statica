/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;
using Statica.Models;
using Statica.Services;

public static class StaticaExtensions
{
    private static StaticStructure[] _structures;

    /// <summary>
    /// Adds the statica module.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <param name="structures">The available structures</param>
    /// <returns>The updated service collection</returns>
    public static IServiceCollection AddStatica(this IServiceCollection services,
        params StaticStructure[] structures)
    {
        // Store the structures for later
        _structures = structures;

        // Add the statica module
        App.Modules.Register<Statica.Module>();

        return services.AddSingleton<IStaticaService>(new StaticaService(structures));
    }

    public static IApplicationBuilder UseStatica(this IApplicationBuilder builder, IWebHostEnvironment env)
    {
        foreach (var structure in _structures)
        {
            if (structure.UseAssets)
            {
                var path = $"{ env.ContentRootPath }/{ structure.DataPath }/_assets";

                // Make sure that the path exists
                if (!Directory.Exists(path))
                    continue;

                // Add the static files provider
                builder.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = $"/{ structure.BaseSlug }/_assets"
                });

            }
        }
        return builder;
    }
}