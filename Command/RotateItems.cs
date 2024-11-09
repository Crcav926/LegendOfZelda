
namespace LegendOfZelda
{
    internal class RotateItems : ICommand
    {

        public RotateItems() 
        {
        }
        public void Execute()
        {
            Link.Instance.inventory.rotateItems();
        }
    }
}
