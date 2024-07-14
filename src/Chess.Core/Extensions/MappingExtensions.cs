namespace Chess.Core.Extensions;

using Models;

public static class MappingExtensions
{
    public static ChessMoveDomainModel ToDomain(this ChessMoveRequest moveRequest) => new()
    {
        Fen = moveRequest.Fen,
        Move = moveRequest.Move
    };

    public static ChessMoveResponse ToResponse(this ChessMoveDomainModel moveRequest) => new()
    {
        Fen = moveRequest.Fen,
        Move = moveRequest.Move
    };
}
