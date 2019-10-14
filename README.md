# Welcome to Statica

![Statica](http://piranhacms.org/assets/icon-statica.png)

## About

Statica is a module for [Piranha CMS](https://www.github.com/piranhacms/piranha.core) that turns
a **recursive** structure of `Markdown` files into a page structure that can be accessed from your
**Piranha website**. The module can for example be used to display documentation on your website that
you want to author and edit somewhere else than through your website.

For example the module will be used on the official [Piranha website](http://www.piranhacms.org) to
render the documentation section.

## Setup

Adding statica to your application is easy. The only important this is that `UseStatica` should be placed **after** `UseStaticFiles` but **before** any dynamic handlers like `Mvc` is added to the middleware pipeline.

    using Statica.Models;

    public void ConfigureServices(IServiceCollection services)
    {
        ...

        //
        // Adds a new statica structure with the base slug
        // docs and assets enabled
        //
        services.AddStatica(new Statica.Models.StaticStructure
        {
            Id = "docs",
            DataPath = "docs/src",
            BaseSlug = "docs",
            UseAssets = true
        });

        ...
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...

        app.UseStaticFiles();
        app.UseStatica(env);

        ...
    }

If `UseAssets` is set to `true`, Statica will **assume** that you have the folder `_assets` in your DataPath. If will be exposed in your application on `BaseSlug/_assets`.