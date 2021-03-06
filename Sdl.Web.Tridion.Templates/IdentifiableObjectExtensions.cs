﻿using Tridion.ContentManager;

namespace Sdl.Web.Tridion
{
    public static class IdentifiableObjectExtensions
    {
        public static string FormatIdentifier(this IdentifiableObject identifiableObject) =>
            $"{identifiableObject.GetType().Name} '{identifiableObject.Title}' ({identifiableObject.Id})";
    }
}
