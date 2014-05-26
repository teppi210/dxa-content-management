﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Tridion.ContentManager.ContentManagement;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace Sdl.Web.Templating
{
    [TcmTemplateTitle("Publish Static Bootstrap")]
    public class PublishStaticBootstrap : TemplateBase.TemplateBase
    {
        private string _moduleRoot = string.Empty;

        public override void Transform(Engine engine, Package package)
        {
            this.Initialize(engine, package);
            //The core configuration component should be the one being processed by the template
            var coreConfigComponent = this.GetComponent();
            var sg = GetSystemStructureGroup();
            //Publish the boostrap list, this is used by the web application to load in all other static files
            PublishBootstrapJson(GetBootstrapFiles(), coreConfigComponent, sg, "statics-");
        }

        private List<string> GetBootstrapFiles()
        {
            List<string> files = new List<string>();
            foreach (var item in MPackage.GetEntries())
            {
                if (item.Key.EndsWith(BootstrapFilename + JsonExtension))
                {
                    files.Add(Json.Encode(item.Key));
                }
            }
            return files;
        }

    }
}
