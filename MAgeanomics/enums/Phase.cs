namespace Mageanomics.Enums
{
    public enum Phase
    {
        Invalid = 0,
        Untap,
        Upkeep,
        Draw,
        FirstMain,
        BeginningOfCombat,
        DeclareAttackers,
        AssignBlockers,
        CombatDamage1, /* First strike and double strike */
        CombatDamage2, /* Regular Strike */
        EndCombat,
        SecomdMain,
        EndStep,
        CleanupStep,/* Discard cards happend here */
        All, /*Static effect*/
    }
}
