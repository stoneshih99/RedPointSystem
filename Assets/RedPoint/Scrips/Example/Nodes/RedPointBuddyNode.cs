using RedPoint.Scrips.Example.Models;
using RedPoint.Scrips.Imp;
using UnityEngine;

namespace RedPoint.Scrips.Example.Nodes
{
    [RequireComponent(typeof(RedPointDisplayImp))]
    public class RedPointBuddyNode  : RedPointAbstractNode
    {
#pragma warning disable
        [SerializeField] private ERedPointBuddy eNode;
#pragma warning restore
        protected override void DoAwake()
        {
            SetNodeName(eNode);
        }

        protected override void DoStart()
        {
            RegisterListener(ERedPointBuddy.Buddies, DoUpdateBuddies);
            RegisterListener(ERedPointBuddy.Message, DoUpdateMessage);
        }

        /// <summary>
        /// 好友數量邏輯計算
        /// </summary>
        /// <param name="objectData"></param>
        private void DoUpdateBuddies(object objectData)
        {
            SetNumCount(2);
        }

        /// <summary>
        /// 好友訊息邏輯計算
        /// </summary>
        /// <param name="objectData"></param>
        private void DoUpdateMessage(object objectData)
        {
            SetNumCount(2);
        }
    }
}