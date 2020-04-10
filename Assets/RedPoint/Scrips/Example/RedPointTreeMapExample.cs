using System;
using System.Collections.Generic;
using RedPoint.Scrips.Example.Models;

namespace RedPoint.Scrips.Example
{
    /// <summary>
    /// 紅點提示的節點樹
    /// </summary>
    public class RedPointTreeMapExample : IRedPointTreeMap
    {
        public Type Nodes { get; }

        private readonly Dictionary<Enum, Type> _tree;
        public Dictionary<Enum, Type> Tree => _tree;

        RedPointTreeMapExample(Type nodes)
        {
            _tree = new Dictionary<Enum, Type>();
            Nodes = nodes;
        }
        
        private void AddChild(Enum parent, Type children)
        {
            _tree.Add(parent, children);
        }
        
        /// <summary>
        /// 手動建立節點之間的關係
        /// Example:
        ///                                          ERedPointMainNode(Mail, Buddy)
        ///                                             /                      \
        ///                ERedPointMailNode(Read, Unread)                     ERedPointBuddyNode(Message, Buddies)
        ///                    /                       \                           /                           \
        ///   ERedPointEmailNode(Read)     ERedPointEmailNode(Unread)    ERedPointMessageNode(Read,Unread)    ERedPointBuddyNode(Message,Buddies)
        ///                                                                  /                         \
        ///                                                  ERedPointMessageNode(Read)     ERedPointMessageNode(Unread)
        /// </summary>                
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static RedPointTreeMapExample Create(Type nodes)
        {
            var tree = new RedPointTreeMapExample(nodes);
            // root/Buddy
            tree.AddChild(ERedPointMainNode.Buddy, typeof(ERedPointBuddy));
            // root/Buddy/BuddyMessage
            tree.AddChild(ERedPointBuddy.Message, typeof(ERedPointBuddyMessage));
            // root/Mail/Message
            tree.AddChild(ERedPointMainNode.Mail, typeof(ERedPointEmail));
            return tree;
        }

        
    }
}