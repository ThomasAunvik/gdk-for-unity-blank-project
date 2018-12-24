using Improbable;
using Improbable.Gdk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GdkTest.Generated;

namespace GdkTest
{
    public static class ObjectTemplate
    {
        public static readonly List<string> AllWorkerAttributes = new List<string>()
        {
            "UnityClient",
            "UnityGameLogic"
        };

        public static EntityTemplate CreateObjectEntityTemplate(Coordinates coords)
        {
            var objectComponent = GdkTest.Generated.Object.Component.CreateSchemaComponentData(message: "test");

            var entity = EntityBuilder.Begin()
                .AddPosition(coords.X, coords.Y, coords.Z, "UnityGameLogic")
                .AddMetadata("Object", "UnityGameLogic")
                .SetPersistence(true)
                .SetReadAcl(AllWorkerAttributes)
                .AddComponent(objectComponent, "UnityGameLogic")
                .Build();

            return entity;
        }
    }
}
