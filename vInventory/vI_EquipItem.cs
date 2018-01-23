using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vInventory")]
	[Tooltip(" ")]
	public class vI_EquipItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vInventory))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vEquipArea))]
		public FsmObject equipArea;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		public FsmBool everyFrame;

		vInventory theScript;
  

		public override void Reset()
		{
			gameObject = null;
			equipArea = null;
			item = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vInventory>();


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
			var vArea = equipArea.Value as vEquipArea;
			if (vArea == null)
			{
				return;
			}
			var iItem = item.Value as vItem;
			if (iItem == null)
			{
				return;
			}
			
			theScript.EquipItem(vArea, iItem);
			
		}

	}
}