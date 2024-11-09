 namespace LegendOfZelda.LinkItems
{
    internal class CommThrowBoomerang: ICommand
    {
        Link link;
            public CommThrowBoomerang(Link link)
            {
                this.link = link;
            }
            public void Execute()
            {
                // HOTFIX - Call attack twice, one to change the state and one to throw the boomerang
                // Formerly would just change states than instantly change back
                this.link.BoomerangAttack();
                this.link.BoomerangAttack();
            }
    }
}
