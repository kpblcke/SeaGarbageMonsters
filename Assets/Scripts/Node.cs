﻿using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Node
    {
        public Vector2Int coordinates;
        public bool isWalkable;
        public bool isExplored;
        public bool isPath;
        public Node connectedTo;

        public Node(Vector2Int coodinates, bool isWalkable)
        {
            this.coordinates = coodinates;
            this.isWalkable = isWalkable;
        }

    }
}