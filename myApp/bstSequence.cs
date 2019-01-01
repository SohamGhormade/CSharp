namespace BST
{
    public class Node
    {
        public Node l, r;
        public int data;
        public Node(int data)
        {
            this.data = data;
        }
    };

    public class Problem4_5
    {
        public int[] bstSequence(Node root, int size)
        {
            if (root == null)
                return null;

            var arr = new int[2 * size];
            bstSeq(root, arr, true);
            bstSeq(root, arr, false);
            return arr;

        }
        private int index = 0;
        private void bstSeq(Node root, int[] arr, bool leftOrder)
        {
            if (root == null) return;
            arr[index] = root.data;
            index++;
            if (leftOrder)
            {
                bstSeq(root.l, arr, true);
                bstSeq(root.r, arr, true);
            }
            else

            {
                bstSeq(root.r, arr, false);
                bstSeq(root.l, arr, false);
            }
        }
    };
}