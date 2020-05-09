namespace Durak.Interfaces
{
    interface IPlayerSetter
    {
        Player player1 { get; }
        Player player2 { get; }
        string UserName { get; }
        void CreatePlayers();
    }
}
