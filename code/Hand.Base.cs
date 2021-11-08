﻿using Sandbox;

namespace VrExample
{
	public partial class BaseHand : AnimEntity
	{
		[Net] public BaseHand Other { get; set; }

		protected virtual string ModelPath => "";

		protected bool GripPressed => InputHand.Grip > 0.5f;
		protected bool TriggerPressed => InputHand.Trigger > 0.5f;

		public virtual Input.VrHand InputHand { get; }

		public override void Spawn()
		{
			SetModel( ModelPath );

			Position = InputHand.Transform.Position;
			Rotation = Rotation.From( 0, 0, 0 );

			EnableDrawing = Local.Client == this.Client;
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			Position = InputHand.Transform.Position;
			Rotation = InputHand.Transform.Rotation;

			Animate();
		}

		private void Animate()
		{
			SetAnimBool( "Grabbing", true ); // TODO
			SetAnimFloat( "Index", InputHand.GetFingerCurl( 1 ) );
			SetAnimFloat( "Middle", InputHand.GetFingerCurl( 2 ) );
			SetAnimFloat( "Ring", InputHand.GetFingerCurl( 3 ) );
			SetAnimFloat( "Thumb", InputHand.GetFingerCurl( 0 ) );
		}
	}
}
