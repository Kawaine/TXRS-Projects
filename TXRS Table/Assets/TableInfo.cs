using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Table")]
public class TableInfo : ScriptableObject
{
    public enum top {Two, Four, Six, Table, HalfTable, Hightop};
    public top Topsize;
    public int maxPartySize;
    public bool extendable;
    public bool wheelChairAccessible;
    public bool raised;
}
