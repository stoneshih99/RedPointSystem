using System;
using UnityEngine;

namespace RedPoint.Scrips.Nodes
{
    public class RedPointSystemBase : MonoBehaviour
    {
        /// <summary>
        /// 節點系統
        /// </summary>
        private RedPointSystem _redPointSystem;

        

        /// <summary>
        /// 初始化關聯的節點樹
        /// 可以參考 Sample:裡的 RedPointTreeMap 建立
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        protected void InitTree(IRedPointTreeMap treeMap)
        {
            _redPointSystem = new RedPointSystem(treeMap);
        }

        

        /// <summary>
        /// 依據 Enum 尋找出節點
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public RedPointNode Find(Enum e)
        {
            return _redPointSystem.Find(e);
        }

        /// <summary>
        /// 取得根節點
        /// </summary>
        /// <returns></returns>
        public RedPointNode GetRoot()
        {
            return _redPointSystem.Root;
        }

        /// <summary>
        /// 建立指定的父節點下所建立的子節點
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="childrenNode"></param>
        protected void CreateNode(Enum parentNode, Type childrenNode)
        {
            _redPointSystem.CreateNode(parentNode, childrenNode);
        }

        /// <summary>
        /// 接被外部的知通後會進行有排序的更新通知
        /// </summary>
        /// <param name="dataObject"></param>
        public void Notify(object dataObject)
        {
            UpdatePriority(_redPointSystem.Root, dataObject);
        }

        /// <summary>
        /// 保持順序性的更新
        /// Tree 是擁有階層的所以更新也要擁有順序
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dataObject"></param>
        private void UpdatePriority(RedPointNode node, object dataObject)
        {
            if (node == null) return;
            
            foreach (var n in node.Children)
            {
                if (n.Children.Count > 0)
                    UpdatePriority(n, dataObject);
                n.Update(dataObject);
                // Debug.Log("DoPriorityUpdate::node Name:"+n.Name);
            }
        }
    }
}