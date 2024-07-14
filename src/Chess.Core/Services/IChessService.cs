namespace Chess.Core.Services;

using Models;

public interface IChessService
{
    ChessMoveDomainModel? MakeMove(ChessMoveDomainModel domain);
}
