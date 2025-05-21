/// Leetcode 700
/// https://leetcode.com/problems/search-in-a-binary-search-tree
/// You are given the root of a binary search tree (BST) and an integer val.
/// Find the node in the BST that the node's value equals val and return the
/// subtree rooted with that node. If such a node does not exist, return null.
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

Demo([4, 2, 7, 1, 3], 2);
Demo([4, 2, 7, 1, 3], 5);
Console.ReadKey();

void Demo(int[] root, int val)
{
    Console.WriteLine($"Searching for {val} in BST [{string.Join(", ",root)}]");
    var node = TreeNode.SearchBST(new(root), val);
    if(node==null) { Console.WriteLine($"{val} not found!"); }
    else { Console.WriteLine(node); }
}


public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    /// <summary>
    /// Create a tree of nodes based on an array representation of tree
    /// </summary>
    /// <param name="vals">list of values in an array representation of tree</param>
    public TreeNode(int[] vals)
    {
        this.val = vals[0];
        TreeNode root = this;
        TreeNode ptr;
        // populate values, starting with vals[1]
        for (int i = 1; i < vals.Length; i++)
        {
            ptr = root;
            if (root.left == null) { ptr.left = new TreeNode(vals[i]); }
            else if (root.right == null) { ptr.right = new TreeNode(vals[i]); }
            else // traverse to correct parent
            {
                //point to parent
                ptr = SearchBST(root, vals[(i-1)/2]);
                if(i%2==1) { ptr.left = new TreeNode(vals[i]); }
                else { ptr.right = new TreeNode(vals[i]); }
            }
        }
    }
    public static TreeNode SearchBST(TreeNode root, int val)
    {
        TreeNode pointer = root;
        while (true)
        {
            if (pointer.val == val) { return pointer; }
            else if (pointer.val > val && pointer.left != null) { pointer = pointer.left; }
            else if (pointer.val < val && pointer.right != null) { pointer = pointer.right; }
            else { return null; }
        }
    }

    public override string ToString()
    {
        string lVal = (left==null)?"null":$"{left.val}";
        string rVal = (right == null) ? "null" : $"{right.val}";
        return $"Node: {val}, Left: {lVal}, Right: {rVal}";
    }
}
