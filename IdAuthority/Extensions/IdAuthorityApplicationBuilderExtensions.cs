﻿// Copyright (c) Ryan Foster. All rights reserved. 
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Reflection;

namespace Microsoft.AspNetCore.Builder
{
    public static class IdAuthorityApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseIdAuthority(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Security
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.SameOrigin());
            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseXfo(options => options.Deny());

            app.UseCsp(opts => opts
                .BlockAllMixedContent()
                .DefaultSources(s => s.Self())
                .ScriptSources(s => {
                    s.Self();
                    s.CustomSources("sha256-VuNUSJ59bpCpw62HM2JG/hCyGiqoPN3NqGvNXQPU+rY=");
                })
                .StyleSources(s => {
                    s.Self();
                    s.UnsafeInline();
                })
                .FrameAncestors(s => s.None())
            );

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new EmbeddedFileProvider(typeof(IdAuthorityApplicationBuilderExtensions).GetTypeInfo().Assembly, "SimpleIAM.IdAuthority.wwwroot")
            });

            app.UseIdentityServer();

            app.UseMvc();

            return app;
        }
    }
}
