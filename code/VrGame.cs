﻿using Sandbox;

namespace VrExample
{
	public partial class VrGame : Sandbox.Game
	{
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new VrPlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}
}
