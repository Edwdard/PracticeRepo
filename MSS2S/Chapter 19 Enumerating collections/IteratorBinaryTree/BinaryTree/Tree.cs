﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace BinaryTree
{
    public class Tree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        public TItem NodeData { get; set; }
        public Tree<TItem>? LeftTree { get; set; }
        public Tree<TItem>? RightTree { get; set; }

        public Tree(TItem nodeValue)
        {
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }

        public void Insert(TItem newItem)
        {
            TItem currentNodeValue = this.NodeData;

            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                // Insert the new item into the left subtree
                if (this.LeftTree is null)
                {
                    this.LeftTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.LeftTree.Insert(newItem);
                }
            }
            else
            {
                // Insert the new item into the right subtree
                if (this.RightTree is null)
                {
                    this.RightTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.RightTree.Insert(newItem);
                }
            }
        }

        public string WalkTree()
        {
            string result = "";

            if (this.LeftTree is not null)
            {
                result = this.LeftTree.WalkTree();
            }

            result += $" {this.NodeData.ToString()} ";

            if (this.RightTree is not null)
            {
                result += this.RightTree.WalkTree();
            }
            return result;
        }

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            //throw new NotImplementedException();
            if (this.LeftTree is not null)
            {
                foreach (TItem item in this.LeftTree)
                {
                    yield return item;
                }
            }
            yield return this.NodeData;
            
            if (this.RightTree is not null)
            {
                foreach(TItem item in this.RightTree)
                {
                    yield return item;
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
