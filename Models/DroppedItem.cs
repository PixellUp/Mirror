using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Models
{
    public class DroppedItem
    {
        public string Name { get; set; }
        public int StackCount { get; set; }
        public Vector3 Position { get; set; }
        public NetHandle SpawnedObject { get; set; }
        public TextLabel TextLabel { get; set; }

        public DroppedItem(Client client, InventoryItem inventoryItem)
        {
            this.Name = inventoryItem.Name;
            this.StackCount = inventoryItem.StackCount;
            this.Position = client.Position;
            // 1778631864
            GTANetworkAPI.Object obj = NAPI.Object.CreateObject(3151838160, new Vector3(client.Position.X, client.Position.Y, client.Position.Z - 0.8), new Vector3(), 255);
            SpawnedObject = obj;
            TextLabel = NAPI.TextLabel.CreateTextLabel($"{inventoryItem.Name}", new Vector3(client.Position.X, client.Position.Y, client.Position.Z - 0.8), 5f, 1f, 4, new Color(255, 255, 255, 255));
        }

        public void PickupItem()
        {
            if (NAPI.Entity.DoesEntityExist(SpawnedObject))
                NAPI.Entity.DeleteEntity(SpawnedObject);

            if (TextLabel != null)
                TextLabel.Delete();
        }
    }
}
