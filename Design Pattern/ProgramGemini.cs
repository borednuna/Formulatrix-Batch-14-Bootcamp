using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringGuru.DesignPatterns.NoComposite.Conceptual
{
    class Leaf
    {
        public string Operation()
        {
            return "Leaf";
        }
    }

    class Composite
    {
        protected List<Leaf> _children = new List<Leaf>();

        public void Add(Leaf component)
        {
            this._children.Add(component);
        }

        public void Remove(Leaf component)
        {
            this._children.Remove(component);
        }

        public string Operation()
        {
            string result = "Branch(";
            result += string.Join("+", this._children.Select(c => c.Operation()));
            return result + ")";
        }
    }

    class Client
    {
        public void ClientCodeForLeaf(Leaf leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        }

        public void ClientCodeForComposite(Composite composite)
        {
            Console.WriteLine($"RESULT: {composite.Operation()}\n");
        }

        public void ClientCodeWithCheck(object component)
        {
            if (component is Leaf leaf)
            {
                Console.WriteLine("Client is handling a Leaf component.");
                Console.WriteLine($"RESULT: {leaf.Operation()}\n");
            }
            else if (component is Composite composite)
            {
                Console.WriteLine("Client is handling a Composite component.");
                Console.WriteLine($"RESULT: {composite.Operation()}\n");
            }
            else
            {
                Console.WriteLine("Client received an unknown component type.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCodeForLeaf(leaf);

            Composite tree = new Composite();
            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());

            tree.Add(new Leaf());
            tree.Add(new Leaf());
            tree.Add(new Leaf());

            Console.WriteLine("Client: Now I've got a composite tree:");
            client.ClientCodeForComposite(tree);

            Console.Write("Client: I must check component types when managing the tree:\n");
            client.ClientCodeWithCheck(tree);
            client.ClientCodeWithCheck(leaf);
        }
    }
}
