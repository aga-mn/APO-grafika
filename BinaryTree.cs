public class BinaryTree
{
   private Node root;

   public BinaryTree()
   {
      root = null;
   }

   #region Metody publiczne
   public virtual void Clear()
   {
      root = null;
   }
   #endregion

   #region Wlasciwosci publiczne
   public Node Root
   {
      get
      {
         return root;
      }
      set
      {
         root = value;
      }
   }
   #endregion
}