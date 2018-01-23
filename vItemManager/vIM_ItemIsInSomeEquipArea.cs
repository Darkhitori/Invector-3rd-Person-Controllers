using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Check if item is in Some area ")]
	public class vIM_ItemIsInSomeEquipArea : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum ItemIsInSomeEquipArea
		{
			id,
			itemName
		}
		
		public ItemIsInSomeEquipArea methods;
		
		public FsmInt id;
		
		public FsmString itemName;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool itemIsInSomeEquipArea;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			methods =  ItemIsInSomeEquipArea.id;
			id = null;
			itemName = "";
			itemIsInSomeEquipArea = false;
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
			
			switch(methods)
			{
			case ItemIsInSomeEquipArea.id:
				itemIsInSomeEquipArea.Value = theScript.ItemIsInSomeEquipArea(id.Value);
				break;
			case ItemIsInSomeEquipArea.itemName:
				itemIsInSomeEquipArea.Value = theScript.ItemIsInSomeEquipArea(itemName.Value);
				break;
			}
			
		}

	}
}