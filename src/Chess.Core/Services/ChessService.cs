namespace Chess.Core.Services;

using System.ComponentModel.DataAnnotations;
using ChessEngine.Engine;
using Models;

public class ChessService : IChessService
{
    public ChessMoveDomainModel? MakeMove(ChessMoveDomainModel domain)
    {
        var engine = string.IsNullOrWhiteSpace(domain.Fen) ? new Engine() : new Engine(domain.Fen!);

        if (string.IsNullOrWhiteSpace(domain.Move) || domain.Move.Length != 4)
        {
            throw new ValidationException("Invalid move format");
        }

        // Do the conversion
        var src = domain.Move[..2];
        var dst = domain.Move.Substring(2, 2);

        var srcCol = GetColumn(src);
        var srcRow = GetRow(src);
        var dstRow = GetRow(dst);
        var dstCol = GetColumn(dst);

        // Validate move
        if (!engine.IsValidMove(srcCol, srcRow, dstCol, dstRow))
        {
            throw new ValidationException("Move is incorrect, cannot move there");
        }

        // Do the player move
        engine.MovePiece(srcCol, srcRow, dstCol, dstRow);

        // Do the AI move
        engine.AiPonderMove();

        // Return the result
        return new ChessMoveDomainModel() { Fen = engine.FEN, Move = engine.LastMove.GetPureCoordinateNotation() };
    }

    private static byte GetRow(string move)
    {
        if (move != null)
        {
            if (move.Length == 2)
            {
                return (byte)(8 - int.Parse(move.Substring(1, 1).ToLower(System.Globalization.CultureInfo.CurrentCulture)));
            }
        }

        return 255;
    }

    private static byte GetColumn(string move)
    {
        if (move != null)
        {
            if (move.Length == 2)
            {
                var col = move[..1].ToLower(System.Globalization.CultureInfo.CurrentCulture);

                switch (col)
                {
                    case "a":
                    {
                        return 0;
                    }
                    case "b":
                    {
                        return 1;
                    }
                    case "c":
                    {
                        return 2;
                    }
                    case "d":
                    {
                        return 3;
                    }
                    case "e":
                    {
                        return 4;
                    }
                    case "f":
                    {
                        return 5;
                    }
                    case "g":
                    {
                        return 6;
                    }
                    case "h":
                    {
                        return 7;
                    }
                    default:
                        return 255;
                }
            }
        }

        return 255;
    }

    //TODO: Implement endgame conditions
    // public string? MakeMove(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow)
    // {
    //     if (!_engine.IsValidMove(sourceColumn, sourceRow, destinationColumn, destinationRow))
    //         return null;
    //
    //     _engine.MovePiece(sourceColumn, sourceRow, destinationColumn, destinationRow);
    //     var output = MakeEngineMove();
    //
    //     if (_engine.StaleMate)
    //     {
    //         if (_engine.InsufficientMaterial)
    //             output += "Draw by insufficient material!";
    //
    //         else if (_engine.RepeatedMove)
    //             output += "Draw by repetition!";
    //
    //         else if (_engine.FiftyMove)
    //             output += "Draw by fifty move rule";
    //
    //         else
    //             output += "Stalemate!";
    //     }
    //     else if (_engine.GetWhiteMate())
    //         output += "Black player has successfully checkmated white!";
    //
    //     else if (_engine.GetBlackMate())
    //         output += "White player has successfully checkmated black!";
    //
    //     return output;
    // }
}
