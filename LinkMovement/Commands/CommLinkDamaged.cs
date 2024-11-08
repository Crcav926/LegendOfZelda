
namespace LegendOfZelda.LinkMovement
{
    internal class CommLinkDamaged : ICommand
    {
        Link link;
        public CommLinkDamaged(Link link)
        {
            this.link = link;

        }
        public void Execute()
        {
            this.link.TakeDamage();
        }
    }
}
