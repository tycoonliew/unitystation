using UnityEngine;
using System;

namespace Chemistry.Effects
{
	[CreateAssetMenu(fileName = "reaction", menuName = "ScriptableObjects/Chemistry/Effect/Item")]
	[Serializable]
	public class Item : Chemistry.Effect
	{
		private MixingBowl senderInfo;
		private Vector3Int senderPosition;
		public GameObject spawnItem;

		public int numberToSpawn = -1;

		public override void Apply(MonoBehaviour sender, float amount)
		{
			amount = (int)Math.Floor(amount);
			if (numberToSpawn != -1)
			{
				amount = numberToSpawn;
			}

			senderPosition = sender.gameObject.RegisterTile().WorldPositionServer;
			senderInfo = sender.gameObject.GetComponent<MixingBowl>();
			if (senderInfo != null)
			{
				if (senderInfo.playerHolding != null)
					Spawn.ServerPrefab(spawnItem, senderInfo.playerHolding.WorldPositionServer, null, null, (int)amount);
				else
					Spawn.ServerPrefab(spawnItem, senderPosition, null, null, (int)amount);
			}
			else
			{
				Spawn.ServerPrefab(spawnItem, senderPosition, null, null, (int)amount);
			}
		}

		public void SpawnStuff()
		{

		}
	}
}