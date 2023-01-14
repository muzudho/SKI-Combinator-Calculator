namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal interface IElement
    {
        IElement Previous { get; set; }
        IElement Next { get; set; }

        void AppendNext(IElement next)
    }
}
