namespace Mageanomics.Enums
{
    /*Prefixed with Whenever or When*/
    public enum Trigger
    {
        Invalid = 0,
        Attacks,
        Blocks,
        Dies,
        EntersTheBattlefield,
        LeavesTheBattlefield,
        BecomesTheTarget,
        Another, /*Whenever another Target */
    }
}
