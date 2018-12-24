using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;
using Improbable.Gdk.GameObjectRepresentation;
using Improbable.Worker.CInterop;
using UnityEngine;

namespace GdkTest
{
    public class EntityCreationBehaviour : MonoBehaviour
    {
        [Require] private WorldCommands.Requirable.WorldCommandRequestSender commandSender;
        [Require] private WorldCommands.Requirable.WorldCommandResponseHandler responseHandler;

        private void OnEnable()
        {
            responseHandler.OnCreateEntityResponse += OnCreateEntityResponse;
        }

        [ContextMenu("Test Create Entity")]
        public void CreateEntity(Coordinates coords)
        {
            EntityTemplate template = ObjectTemplate.CreateObjectEntityTemplate(coords);
            commandSender.CreateEntity(template);
        }

        void OnCreateEntityResponse(WorldCommands.CreateEntity.ReceivedResponse response)
        {
            if (response.StatusCode == StatusCode.Success)
            {
                var createdEntityId = response.EntityId.Value;
                if(response.Context is Generated.Object)
                {
                    Generated.Object obj = response.Context as Generated.Object;
                    Debug.Log("Created Entity Object...");
                }
                Debug.Log("Recieved Object");
            }
            else
            {
                // handle failure
                Debug.LogError("Failed Recieving Object.\n" + response.Message);
            }
        }
    }
}
