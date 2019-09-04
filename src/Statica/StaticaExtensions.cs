/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using Microsoft.Extensions.DependencyInjection;
using Piranha;
using Statica.Models;
using Statica.Services;

public static class StaticaExtensions
{
    /// <summary>
    /// Adds the statica module.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <param name="structures">The available structures</param>
    /// <returns>The updated service collection</returns>
    public static IServiceCollection AddStatica(this IServiceCollection services,
        params StaticStructure[] structures)
    {
        // Add the statica module
        App.Modules.Register<Statica.Module>();

        return services.AddSingleton<IStaticaService>(new StaticaService(structures));
    }
}