public class Node
{
   private object data;
   private Node left, right;

   #region Konstruktory
   public Node() : this(null) {}
   public Node(object data) : this(data, null, null) {}
   public Node(object data, Node left, Node right)
   {
      this.data = data;
      this.left = left;
      this.right = right;
   }
   #endregion

   #region Wlasciwosci publiczne
   public object Value
   {
      get
      {
         return data;
      }
      set
      {
         data = value;
      }
   }

   public Node Left
   {
      get
      {
         return left;
      }
      set
      {
         left = value;
      }
   }

   public Node Right
   {
      get
      {
         return right;
      }
      set
      {
         right = value;
      }
   }
   #endregion
}