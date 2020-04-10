using RedPoint.Scrips.Example.Models;
using RedPoint.Scrips.Imp;
using UnityEngine;

namespace RedPoint.Scrips.Example.Nodes
{
    [RequireComponent(typeof(RedPointDisplayImp))]
    public class RedPointBuddyMessage  : RedPointAbstractNode
    {
#pragma warning disable
        [SerializeField] private ERedPointBuddyMessage eNode;
#pragma warning restore
        protected override void DoAwake()
        {
            SetNodeName(eNode);
        }

        protected override void DoStart()
        {
            RegisterListener(ERedPointBuddyMessage.Read, OnUpdateRead);
            RegisterListener(ERedPointBuddyMessage.Unread, OnUpdateUnread);
        }

        /// <summary>
        /// 好友訊息已讀邏輯計算
        /// </summary>
        /// <param name="objectData"></param>
        private void OnUpdateRead(object objectData)
        {
            SetNumCount(2);
        }

        /// <summary>
        /// 好友訊息未讀邏輯計算
        /// </summary>
        /// <param name="objectData"></param>
        private void OnUpdateUnread(object objectData)
        {
            SetNumCount(2);
        }
    }
}