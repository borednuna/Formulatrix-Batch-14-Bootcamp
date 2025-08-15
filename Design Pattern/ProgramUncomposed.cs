using System;
using System.Collections.Generic;

namespace WithoutCompositePattern
{
    // Just a leaf class
    class Leaf
    {
        public string Operation()
        {
            return "Leaf";
        }
    }

    // A branch that holds leaves or other branches
    class Branch
    {
        private List<object> _children = new List<object>();

        public void AddLeaf(Leaf leaf)
        {
            _children.Add(leaf);
        }

        public void AddBranch(Branch branch)
        {
            _children.Add(branch);
        }

        public string Operation()
        {
            int i = 0;
            string result = "Branch(";
            foreach (var child in _children)
            {
                if (child is Leaf leaf)
                {
                    result += leaf.Operation();
                }
                else if (child is Branch branch)
                {
                    result += branch.Operation();
                }

                if (i != _children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }
            return result + ")";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Build the structure manually
            Leaf leaf = new Leaf();

            Branch branch1 = new Branch();
            branch1.AddLeaf(new Leaf());
            branch1.AddLeaf(new Leaf());

            Branch branch2 = new Branch();
            branch2.AddLeaf(new Leaf());

            Branch tree = new Branch();
            tree.AddBranch(branch1);
            tree.AddBranch(branch2);

            Console.WriteLine(leaf.Operation());   // OK, but only works for Leaf
            Console.WriteLine(tree.Operation());   // Works for Branch
        }
    }
}
