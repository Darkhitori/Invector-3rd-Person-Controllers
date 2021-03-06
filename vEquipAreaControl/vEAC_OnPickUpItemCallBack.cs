﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.ItemManager;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Invector/vEquipAreaControl")]
	[Tooltip(" ")]
	public class vEA_OnPickUpItemCallBack : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(vEquipAreaControl))] 
		public FsmOwnerDefault gameObject;
		
		[ObjectType(typeof(vEquipArea))]
		public FsmObject area;
		
		[ObjectType(typeof(vItemSlot))]
		public FsmObject slot;
		
		public FsmEvent sendEvent;
		
		public FsmBool everyFrame;

		vEquipAreaControl theScript;
  

		public override void Reset()
		{
			gameObject = null;
			area = null;
			slot = null;
			sendEvent = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<vEquipAreaControl>();


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
			var vArea = area.Value as vEquipArea;
			if (vArea == null)
			{
				return;
			}
			var vSlot = slot.Value as vItemSlot;
			if (vSlot == null)
			{
				return;
			}
			
			theScript.OnPickUpItemCallBack(vArea, vSlot);
			if (sendEvent == null)
			{
				return;
			}
			else
			{
				Fsm.Event(sendEvent);
			}
		}

	}
}