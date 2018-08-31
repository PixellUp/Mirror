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
            Position = new Vector3(client.Position.X, client.Position.Y, client.Position.Z - 0.8).Around(2);
            Name = inventoryItem.Name.ToUpper();
            StackCount = inventoryItem.StackCount;
            TextLabel = NAPI.TextLabel.CreateTextLabel($"{inventoryItem.Name} ({StackCount})", new Vector3(Position.X, Position.Y, Position.Z + 0.5), 5f, 1f, 4, new Color(255, 255, 255, 255));
            SetObjectType();
        }

        private void SetObjectType()
        {
            switch(Name.ToLower())
            {
                case "medkit":
                    SpawnedObject = NAPI.Object.CreateObject(3792764623, Position, new Vector3(), 255);
                    break;
                case "coffee":
                    SpawnedObject = NAPI.Object.CreateObject(3696781377, Position, new Vector3(), 255);
                    break;
                case "burger":
                    SpawnedObject = NAPI.Object.CreateObject(4098414302, Position, new Vector3(), 255);
                    break;
                case "pills":
                    SpawnedObject = NAPI.Object.CreateObject(4126380171, Position, new Vector3(), 255);
                    break;
                case "material":
                    SpawnedObject = NAPI.Object.CreateObject(4126380171, Position, new Vector3(), 255);
                    break;
                case "ammo":
                    SpawnedObject = NAPI.Object.CreateObject(2872701481, Position, new Vector3(), 255);
                    break;
                default:
                    SpawnedObject = NAPI.Object.CreateObject(3151838160, Position, new Vector3(), 255);
                    break;
            }

            NAPI.Data.SetEntitySharedData(SpawnedObject, "Dropped_Item", Name);
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
