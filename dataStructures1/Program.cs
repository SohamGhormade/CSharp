using System;
using System.Diagnostics;
namespace dataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new HeapTest();
            heap.test();
            BSTTest();
            QueueTest();
            StackTest();
            MyStackTest();
            LinkedListTest();
            var graphTest = new GraphTest();
            graphTest.test();
            Console.WriteLine("All Tests passed!");
        }

      static void BSTTest()
      {
          var bst = new BST<int>();

          bst.insert(17);
          bst.insert(25);
          bst.insert(5);
          bst.insert(8);
          bst.insert(1);
          bst.insert(15);
          bst.insert(6);
          bst.insert(11);
          bst.insert(10);
          bst.insert(26);
          bst.insert(29);

// traversals
          bst.inorder();
          bst.pre();
          bst.post();

          Console.WriteLine("Delete 25");
          bst.delete(25);
          bst.inorder();

          Console.WriteLine("Delete 17");
          bst.delete(17);
          bst.inorder();

          Console.WriteLine("Delete 8");
          bst.delete(8);
          bst.inorder();

          Console.WriteLine("Delete 1");
          bst.delete(1);
          bst.inorder();
      }
        static void HashTableTest()
        {
          var hashTable = new HashTable<string,int>();
          hashTable.put("hi",4);
          hashTable.put("hello",55);
          hashTable.put("parth",5);
          hashTable.put("abc",53);
          hashTable.put("xyz",54);
          hashTable.put("aaa",55);
          hashTable.put("allstate",1155);

          Debug.Assert(hashTable.get("allstate")==1155);
          hashTable.put("allstate",11);
          Debug.Assert(hashTable.get("allstate")==11);
          Debug.Assert(hashTable.get("allstate")==11);
          Debug.Assert(hashTable.get("abc")==53);
          Debug.Assert(hashTable.get("a")==default(int));
        //   hashTable.put("allstate", null);
        //   Debug.Assert(hashTable.get("allstate")==default(int));



        }

        static void QueueTest()
        {
            var queue = new Queue<int>();
            Debug.Assert(queue.isEmpty());

            queue.enqueue(5);
            Debug.Assert(!queue.isEmpty());
            Debug.Assert(1 == queue.size());

            queue.enqueue(1);
            queue.enqueue(-1);
            queue.enqueue(55);
            queue.enqueue(5);
            queue.enqueue(52);
            queue.enqueue(53);
            Debug.Assert(7 == queue.size());

            Debug.Assert(5 == queue.dequeue());
            Debug.Assert(6 == queue.size());

            queue.enqueue(22);
            Debug.Assert(7 == queue.size());

            Debug.Assert(1 == queue.dequeue());
            Debug.Assert(-1 == queue.dequeue());
            Debug.Assert(55 == queue.dequeue());
            Debug.Assert(5 == queue.dequeue());
            Debug.Assert(52 == queue.dequeue());
            Debug.Assert(53 == queue.dequeue());
            Debug.Assert(22 == queue.dequeue());
            Debug.Assert(queue.isEmpty());
            try
            {
                queue.dequeue();
            }
            catch (Exception e)
            {
                Debug.Assert(e.Message.Equals("No elements to remove."));
            }
        }

        static void MyStackTest()
        {
            var stack = new MyStack<int>();//
            Debug.Assert(stack.isEmpty());
            try
            {
                stack.pop();

            }
            catch (Exception e)
            {
                Debug.Assert(e.Message == "No elements to remove!");
            }
            stack.push(1);
            stack.push(5);
            stack.push(100);
            stack.push(10);
            stack.push(101);
            stack.push(103);
            stack.push(104);
            stack.push(14);
            stack.push(410);

            Debug.Assert(!stack.isEmpty());

            Debug.Assert(9 == stack.size());
            Debug.Assert(410 == stack.pop());
            Debug.Assert(8 == stack.size());

            stack.push(14);
            stack.push(410);
            Debug.Assert(10 == stack.size());

            Debug.Assert(410 == stack.pop());
            Debug.Assert(14 == stack.pop());
            Debug.Assert(14 == stack.pop());
            Debug.Assert(104 == stack.pop());
            Debug.Assert(103 == stack.pop());
            Debug.Assert(101 == stack.pop());
            Debug.Assert(10 == stack.pop());
            Debug.Assert(100 == stack.pop());
            Debug.Assert(5 == stack.pop());
            Debug.Assert(1 == stack.pop());
            Debug.Assert(stack.isEmpty());
        }

        static void StackTest()
        {
            var stack = new Stack<int>();
            // TODO:always initialize the variables in tests with C#.Otherwise they will be set to 0 for primitive types.
            // and null for user defined types.
            //Program.cs(41,26): error CS0165: Use of unassigned
            //local variable 'stack' [/home/soham/Documents/Repositories/C#/dataStructures/dataStructures.csproj]
            Debug.Assert(stack.isEmpty());
            try
            {
                stack.pop();

            }
            catch (Exception e)
            {
                Debug.Assert(e.Message == "No elements to remove!");
            }
            stack.push(1);
            stack.push(5);
            stack.push(100);
            stack.push(10);
            stack.push(101);
            stack.push(103);
            stack.push(104);
            stack.push(14);
            stack.push(410);

            Debug.Assert(!stack.isEmpty());

            Debug.Assert(9 == stack.size());
            Debug.Assert(410 == stack.pop());
            Debug.Assert(8 == stack.size());

            stack.push(14);
            stack.push(410);
            Debug.Assert(10 == stack.size());

            Debug.Assert(410 == stack.pop());
            Debug.Assert(14 == stack.pop());
            Debug.Assert(14 == stack.pop());
            Debug.Assert(104 == stack.pop());
            Debug.Assert(103 == stack.pop());
            Debug.Assert(101 == stack.pop());
            Debug.Assert(10 == stack.pop());
            Debug.Assert(100 == stack.pop());
            Debug.Assert(5 == stack.pop());
            Debug.Assert(1 == stack.pop());
            Debug.Assert(stack.isEmpty());
        }
        static void LinkedListTest()
        {
            var linkedList = new LinkedList<int>();
            Debug.Assert(linkedList.isEmpty());

            linkedList.insertAtBeg(11);
            Debug.Assert(!linkedList.isEmpty());
            Debug.Assert(1 == linkedList.size());

            linkedList.insertAtBeg(52);
            linkedList.insertAtBeg(13);
            linkedList.insertAtBeg(64);
            Debug.Assert(4 == linkedList.size());

            linkedList.insertAtEnd(72);
            Debug.Assert(5 == linkedList.size());

            Debug.Assert(64 == linkedList.removeAtBeg());
            Debug.Assert(4 == linkedList.size());

            Debug.Assert(72 == linkedList.removeAtEnd());
            Debug.Assert(3 == linkedList.size());
        }
    }
}
