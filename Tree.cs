using System;
using System.Collections.Generic;

namespace NChildTree
{
    public class Tree<T> : ErrorHandeling
    {
        // Nodes in the tree
        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Parent { get; set; }
            public List<TreeNode> Children { get; set; }
        }

        private int maxChildren, level = -1;

        public TreeNode Root { get; set; }

        private List<int> treeNodes = new List<int>();
        // Parametarized constructer with value of containing the max no of children a node can have 
        public Tree(int no_of_children)
        {
            maxChildren = no_of_children;
        }

        // Method Used to insert new Node in tree
        public void Insert()
        {
            int value;
            // Inserting for the condition if Tree is empty
            if (Root == null)
            {
                value = GetRootValue();
                Root = new TreeNode() { Value = value, Parent = null };
                treeNodes.Add(value);
                level++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nInserted Successfully!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            value = GetValue();
            int parent = GetParent();
            // Checking if the parent entered is in the tree
            if (Contains(parent))
            {
                // If the value of newNode is not already in the tree then only we Insert. i.e. A tree cannot have duplicate values
                if (Contains(value) == false)
                {
                    var temp = Root;
                    // If the parent is the root node
                    if (parent == Root.Value)
                    {
                        InsertCondition(Root, value);
                        if (level < 2)
                        {
                            level = 1;
                        }
                    }

                    else
                    {
                        TraverseTree(Root, parent, value);
                    }
                }
                else
                {
                    Console.WriteLine("\nTree cannot have same value multiple times");
                }
            }
            else
            {
                Console.WriteLine("\nSorry! No such parent present in Tree");
            }

        }

        // Method is use to traverse a tree
        public void TraverseTree(TreeNode root, int parent, int value)
        {
            var local = root.Children;
            while (local != null)
            {
                var list = root.Children;
                foreach (var i in list)
                {

                    if (i.Value == parent)
                    {
                        InsertCondition(i, value);
                        if (level != 3)
                        {
                            level = 2;
                        }
                        return;
                    }

                }
                for (int i = 0; i < maxChildren; i++)
                {
                    var temp = local[i].Children;
                    if (temp != null)
                    {
                        foreach (var j in temp)
                        {
                            if (j.Value == parent)
                            {
                                InsertCondition(j, value);
                                level = 3;
                                return;
                            }
                            level = 3;
                        }
                    }
                }
            }
        }

        // Method used to print all child nodes of a give node
        public void GetElementByValue()
        {
            // Condition for if tree is empty
            if (Root == null)
            {
                Console.WriteLine("\nTree is empty");
                return;
            }
            int value = GetValue();
            // If Value entered is in the tree
            if (Contains(value))
            {
                // If Value at root
                if (Root.Value == value)
                {
                    Comparision(Root);
                }

                var temp = Root.Children;
                // If value at root's children
                foreach (var i in temp)
                {
                    if (i.Value == value)
                    {
                        Comparision(i);
                        return;
                    }
                }
                // If value at root's childrens children
                var local = Root.Children;
                for (int i = 0; i < local.Count; i++)
                {
                    var temp1 = local[i].Children;
                    if (temp1 != null)
                    {
                        foreach (var j in temp1)
                        {
                            if (j.Value == value)
                            {
                                Comparision(j);
                            }
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("\nNo such element in tree");
            }
        }

        // Method is used to print all the nodes in the level
        public void GetElementByLevel()
        {
            if (Root == null)
            {
                Console.WriteLine("\nTree is empty");
                return;
            }
            int levelTree = GetValueLevel();

            if (levelTree == 0)
            {
                Console.Write("\nTree nodes on level 0: ");
                Console.Write(Root.Value);
            }
            else if (levelTree == 1)
            {
                Console.Write("\nTree nodes on level 1: ");
                foreach (var i in Root.Children)
                {
                    Console.Write(i.Value + " ");
                }
            }
            else if (levelTree == 2)
            {
                var temp = Root.Children;
                Console.Write("\nTree nodes on level 2: ");
                foreach (var i in temp)
                {
                    if (i.Children != null)
                    {
                        foreach (var j in i.Children)
                        {
                            Console.Write(j.Value + " ");
                        }
                    }
                }
            }
            else if (levelTree == 3)
            {
                var temp = Root.Children;
                Console.Write("\nTree nodes on level 3: ");
                foreach (var i in temp)
                {
                    if (i.Children != null)
                    {
                        foreach (var j in i.Children)
                        {
                            if (j.Children != null)
                            {
                                foreach (var k in j.Children)
                                {
                                    Console.Write(k.Value + " ");
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                Console.WriteLine("\nThe Max Level in this Tree is 3.");
            }
        }

        // Method used to delete all leaf nodes
        public void Delete()
        {
            // If Tree is empty
            if (Root == null)
            {
                Console.WriteLine("\nTree is empty");
                return;
            }
            // If root at level 0 i.e. at root
            if (level == 0)
            {
                Root = null;
                treeNodes.Clear();
            }
            // If root at level 1 i.e. at root's children
            else if (level == 1)
            {
                foreach (var i in Root.Children)
                {
                    treeNodes.Remove(i.Value);
                }
                Root.Children = null;
                level = 0;
            }
            // If root at level 2
            else if (level == 2)
            {
                var local = Root.Children;
                foreach (var i in local)
                {
                    if (i.Children != null)
                    {
                        foreach (var k in i.Children)
                        {
                            treeNodes.Remove(k.Value);
                        }
                        i.Children = null;
                    }
                }
                level = 1;
            }
            // If root at level 3
            else
            {
                var local = Root.Children;
                foreach (var i in local)
                {
                    if (i.Children != null)
                    {
                        foreach (var k in i.Children)
                        {
                            if (k.Children != null)
                            {
                                foreach (var t in k.Children)
                                {
                                    treeNodes.Remove(t.Value);
                                }
                                k.Children = null;
                            }
                        }
                    }
                }
                level = 2;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll Leaf Node Deleted!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Method used to print children of given node
        public void Comparision(TreeNode root)
        {
            if (root.Children != null)
            {
                Console.Write("\nChildren of The nodes are: ");
                foreach (var i in root.Children)
                {
                    Console.Write(i.Value + " ");
                }
            }
            else
            {
                Console.WriteLine("\nThere are no child nodes for the Input node in tree");
            }
            return;
        }

        // Print in Breadth First Search
        public void PrintBFS()
        {
            if (Root == null)
            {
                Console.WriteLine("\nTree is empty");
                return;
            }
            Console.Write("\nTree Using BFS: ");
            var local = Root.Children;
            Console.Write(Root.Value + " ");

            if (Root.Children == null) { return; }
            foreach (var i in local)
            {
                Console.Write(i.Value + " ");
            }
            for (int i = 0; i < local.Count; i++)
            {
                var temp = local[i].Children;
                if (temp != null)
                {
                    foreach (var j in temp)
                    {
                        Console.Write(j.Value + " ");
                        if (j.Children != null)
                        {
                            foreach (var k in j.Children)
                            {
                                Console.Write(k.Value + " ");
                            }
                        }
                    }
                }
            }

        }

        // Print in Depth First Search
        public void PrintDFS()
        {
            List<int> queue = new List<int>();
            if (Root == null)
            {
                Console.WriteLine("\nTree is empty");
                return;
            }
            Console.Write("\nTree Using DFS: ");
            var local = Root.Children;
            Console.Write(Root.Value + " ");
            queue.Add(Root.Value);

            if (Root.Children == null) { return; }
            foreach (var i in local)
            {
                DFSQueue(queue, i.Value);
                for (int t = 0; t < local.Count; t++)
                {
                    var temp = local[t].Children;
                    if (temp != null)
                    {
                        foreach (var j in temp)
                        {
                            DFSQueue(queue, j.Value);
                            if (j.Children != null)
                            {
                                foreach (var k in j.Children)
                                {
                                    DFSQueue(queue, k.Value);
                                }
                            }
                        }
                    }
                }
            }

        }

        // Checks if Value is in Tree
        public bool Contains(int value)
        {
            foreach (int i in treeNodes)
            {
                if (i == value)
                {
                    return true;
                }
            }
            return false;
        }

        // Condition to insert
        public void InsertCondition(TreeNode temp, int value)
        {
            // If given node has no children we create a new list of children and add
            if (temp.Children == null)
            {
                temp.Children = new List<TreeNode>()
              {
                 new TreeNode() {Value = value,Parent=temp}
              };
                treeNodes.Add(value);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nInserted Successfully!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            // If given node has children but less than the max children allowed
            if (temp.Children.Count != maxChildren)
            {
                TreeNode newNode = new TreeNode() { Value = value, Parent = temp };
                temp.Children.Add(newNode);
                treeNodes.Add(value);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nInserted Successfully!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            // if a node has already used all the max children
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Root Already has max no of children! Cannot Add more!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Iterator for BFS
        public void IteratorBFS()
        {
            if (Root == null)
            {
                Console.WriteLine("\nTree is empty!");
                return;
            }


            IEnumerable<TreeNode> tree = GetIteratedTreeBFS();
            Console.WriteLine("\nTree using Iterator BFS: ");
            foreach (var i in tree)
            {
                Console.WriteLine("{0}", i.Value);
            }
        }
        public IEnumerable<TreeNode> GetIteratedTreeBFS()
        {
            var local = Root.Children;
            yield return Root;

            foreach (var i in local)
            {
                yield return i;
            }
            for (int i = 0; i < local.Count; i++)
            {
                var temp = local[i].Children;
                if (temp != null)
                {
                    foreach (var j in temp)
                    {
                        yield return j;
                        if (j.Children != null)
                        {
                            foreach (var k in j.Children)
                            {
                                yield return k;
                            }
                        }
                    }
                }
            }
        }

        // Iterator for DFS
        public void IteratorDFS()
        {
            if (Root == null)
            {
                Console.WriteLine("\nTree is empty!");
                return;
            }


            IEnumerable<TreeNode> tree = GetIteratedTreeDFS();
            Console.WriteLine("\nTree using Iterator DFS: ");
            foreach (var i in tree)
            {
                Console.WriteLine("{0}", i.Value);
            }
        }

        public IEnumerable<TreeNode> GetIteratedTreeDFS()
        {
            List<int> queue = new List<int>();
            var local = Root.Children;
            yield return Root;
            queue.Add(Root.Value);
            foreach (var i in local)
            {
                if (DFSQueueIterator(queue, i.Value) == 1)
                {
                    yield return i;
                }
                for (int t = 0; t < local.Count; t++)
                {
                    var temp = local[t].Children;
                    if (temp != null)
                    {
                        foreach (var j in temp)
                        {
                            if (DFSQueueIterator(queue, j.Value) == 1)
                            {
                                yield return j;
                            }
                            if (j.Children != null)
                            {
                                foreach (var k in j.Children)
                                {
                                    if (DFSQueueIterator(queue, k.Value) == 1)
                                    {
                                        yield return k;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
