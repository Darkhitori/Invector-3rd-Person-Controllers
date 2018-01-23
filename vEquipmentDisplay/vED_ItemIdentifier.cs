using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vEquipmentDisplay")]
	[Tooltip(" ")]
	public class vED_ItemIdentifier : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vEquipmentDisplay))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt identifier;
		
		public FsmBool showIdentifier;
		
		public FsmBool everyFrame;

		vEquipmentDisplay theScript;
  

		public override void Reset()
		{
			gameObject = null;
			identifier = null;
			showIdentifier = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vEquipmentDisplay>();


			if (!everyFrame.Value)
			{
				DoTheMagic();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMagic();
			}
		}

		void DoTheMagic()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			theScript.ItemIdentifier(identifier.Value, showIdentifier.Value);
			
		}

	}
}