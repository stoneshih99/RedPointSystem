using System.Collections;
using RedPoint.Scrips.Nodes;
using UnityEngine;

namespace RedPoint.Scrips.Example
{
    public class RedPointMainExample : MonoBehaviour
    {
#pragma warning disable
        [Range(1, 5)] [SerializeField] private int duration = 1;
        [SerializeField] private RedPointSystemBase redPointSystemBase;
#pragma warning restore
        private void Start()
        {
            StartCoroutine(EDebug(duration));
        }

        private IEnumerator EDebug(int value)
        {
            yield return new WaitForSeconds(value);
            redPointSystemBase.Notify(null);
        }
    }
}