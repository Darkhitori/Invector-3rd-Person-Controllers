using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vItemManager")]
	[Tooltip("Get a single Item with same id ")]
	public class vIM_GetItem : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vItemManager))] 
		public FsmOwnerDefault gameObject;
		
		public enum GetItem
		{
			id,
			itemName
		}
		
		public GetItem methods;
		
		public FsmInt id;
		
		public FsmString itemName;
		
		[ActionSection("Return")]
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(vItem))]
		public FsmObject getItem;
		
		public FsmBool everyFrame;

		vItemManager theScript;
		
		public override void Reset()
		{
			gameObject = null;
			methods =  GetItem.id;
			id = null;
			itemName = "";
			getItem = null;
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
			case GetItem.id:
				getItem.Value = theScript.GetItem(id.Value);
				break;
			case GetItem.itemName:
				getItem.Value = theScript.GetItem(itemName.Value);
				break;
			}
			
		}

	}
}