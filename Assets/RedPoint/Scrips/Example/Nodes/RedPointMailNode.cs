using RedPoint.Scrips.Example.Models;
using RedPoint.Scrips.Imp;
using UnityEngine;

namespace RedPoint.Scrips.Example.Nodes
{
    [RequireComponent(typeof(RedPointDisplayImp))]
    public class RedPointMailNode  : RedPointAbstractNode
    {
#pragma warning disable
        [SerializeField] private ERedPointEmail eNode;
#pragma warning restore

        protected override void DoAwake()
        {
            SetNodeName(eNode);
        }

        protected override void DoStart()
        {
            RegisterListener(ERedPointEmail.Read, OnUpdateReadMessage);
            RegisterListener(ERedPointEmail.Unread, OnUpdateUnreadMessage);
        }

        /// <summary>
        /// 信件已讀邏輯計算
        /// </summary>
        /// <param name="objectData"></param>
        private void OnUpdateReadMessage(object objectData)
        {
            SetNumCount(1);
        }

        /// <summary>
        /// 信件未讀邏輯計算
        /// </summary>
        /// <param name="objectData"></param>
        private void OnUpdateUnreadMessage(object objectData)
        {
            SetNumCount(0);
        }
    }
}