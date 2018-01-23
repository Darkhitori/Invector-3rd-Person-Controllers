using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Check if the item is equipped in some EquipPoint ")]
	public class vIM_ItemIsInSomeEquipPont : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum ItemIsInSomeEquipPont
		{
			id,
			itemName
		}
		
		public ItemIsInSomeEquipPont methods;
		
		public FsmInt id;
		
		public FsmString itemName;
		
		[ActionSection("Return")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool itemIsInSomeEquipPont;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			methods = ItemIsInSomeEquipPont.id;
			id = null;
			itemName = "";
			itemIsInSomeEquipPont = false;
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
			case ItemIsInSomeEquipPont.id:
				itemIsInSomeEquipPont.Value = theScript.ItemIsInSomeEquipPont(id.Value);
				break;
			case ItemIsInSomeEquipPont.itemName:
				itemIsInSomeEquipPont.Value = theScript.ItemIsInSomeEquipPont(itemName.Value);
				break;
			}
			
			
				
		}

	}
}