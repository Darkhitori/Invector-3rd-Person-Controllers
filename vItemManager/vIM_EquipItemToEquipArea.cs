using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Equip item to specific area and specific slot ")]
	public class vIM_EquipItemToEquipArea : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt indexOfArea;
		
		public FsmInt indexOfSlot;
		
		[ObjectType(typeof(vItem))]
		public FsmObject item;
		
		public FsmBool immediate;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			indexOfArea = null;
			indexOfSlot = null;
			item = null;
			immediate = false;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vItemManager>();


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
			
			var iItem = item.Value as vItem;
			if (iItem == null)
			{
				return;
			}
			
			theScript.EquipItemToEquipArea(indexOfArea.Value, indexOfSlot.Value, iItem, immediate.Value);
			
		}

	}
}