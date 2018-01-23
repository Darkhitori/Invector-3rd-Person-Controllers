using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vEquipArea")]
	[Tooltip(" ")]
	public class vEA_RemoveItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vEquipArea))] 
		public FsmOwnerDefault gameObject;
		
		public enum RemoveItem
		{
			no_parameters,
			slot,
			item
		}
		
		public RemoveItem methods;
		
		[ObjectType(typeof(vEquipSlot))]
		public FsmObject slot;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		public FsmBool everyFrame;

		vEquipArea theScript;
  

		public override void Reset()
		{
			gameObject = null;
			methods =  RemoveItem.no_parameters;
			slot = null;
			item = null;
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
			
			
			switch(methods)
			{
			case RemoveItem.no_parameters:
				theScript.RemoveItem();
				break;
			case RemoveItem.slot:
				var vSlot = slot.Value as vEquipSlot;
				if (vSlot == null)
				{
					return;
				}
				theScript.RemoveItem(vSlot);
				break;
			case RemoveItem.item:
				var vItem = item.Value as vItem;
				if (vItem == null)
				{
					return;
				}
				theScript.RemoveItem(vItem);
				break;
			}
			
			
		}

	}
}