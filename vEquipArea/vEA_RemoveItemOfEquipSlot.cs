using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vEquipArea")]
	[Tooltip(" ")]
	public class vEA_RemoveItemOfEquipSlot : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vEquipArea))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt indexOfSlot;
		
		public FsmBool everyFrame;

		vEquipArea theScript;
  

		public override void Reset()
		{
			gameObject = null;
			indexOfSlot = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vEquipArea>();


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
			
			theScript.RemoveItemOfEquipSlot(indexOfSlot.Value);
			
		}

	}
}