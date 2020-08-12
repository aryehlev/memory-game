﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Match_game_logic
{ 
    public enum eAiModes
    {
        Off,
        Random
        ////Easy,
        ////Normal,
        ////Genius
    }

    public class AiForComputerPlay
    {
        //// private readonly int r_MemoryDepth;
        //// public const int k_MediumMemory = 4;
        //// private readonly List<BoardCoordinates> r_Memory;
        ////private readonly eAiModes r_AiMode;
        
        public AiForComputerPlay(eAiModes i_AiMode)
        {
            ////this.r_AiMode = i_AiMode;
            ////this.r_Memory = new List<BoardCoordinates>();
            ////switch (this.r_AiMode)
            ////{
            ////    //case eAiModes.Easy:
            ////    //    this.r_MemoryDepth = k_MediumMemory;
            ////    //    break;
            ////    //case eAiModes.Normal:
            ////    //    this.r_MemoryDepth = int.MaxValue;
            ////    //    break;
            ////    default:
            ////        this.r_MemoryDepth = 0;
            ////        break;
            ////}
        }

        public BoardCoordinates[] GetCardsForNextMove(GameBoard i_GameBoard)
        {
            List<BoardCoordinates> possibleBoardCoordinates = new List<BoardCoordinates>();
            int heightOfBoard = i_GameBoard.GetHeightOfBoard();
            int lengthOfBoard = i_GameBoard.GetLengthOfBoard();
            
            for (int i = 0; i < heightOfBoard; i++)
            {
                for (int j = 0; j < lengthOfBoard; j++)
                {
                    BoardCoordinates currentBoardCoordinates = new BoardCoordinates(i, j);

                    if (!possibleBoardCoordinates.Contains(currentBoardCoordinates) && !i_GameBoard.GetCardByCoordinates(currentBoardCoordinates).Exposed)
                    {
                        possibleBoardCoordinates.Add(currentBoardCoordinates);
                    }
                }
            }

            Random rnd = new Random();
            int firstCardIdx = rnd.Next(0, possibleBoardCoordinates.Count);
            BoardCoordinates firstChoiceOfCoordinates = possibleBoardCoordinates.ElementAt(firstCardIdx);
            possibleBoardCoordinates.Remove(firstChoiceOfCoordinates);
            int secondCardIdx = rnd.Next(0, possibleBoardCoordinates.Count);
            BoardCoordinates secondChoiceOfCoordinates = possibleBoardCoordinates.ElementAt(secondCardIdx);
            ///this.r_Memory.Remove(firstChoiceBoardCoordinates);

            ////if (this.r_AiMode == eAiModes.Genius)
            ////{
            ////    bool found = false;
            ////    foreach (BoardCoordinates boardCoordinates1 in this.r_Memory)
            ////    {
            ////        if (found)
            ////        {
            ////            break;
            ////        }

            ////        foreach (BoardCoordinates boardCoordinates2 in this.r_Memory)
            ////        {
            ////            if (i_GameBoard.GetCardByCoordinates(boardCoordinates1).Letter == i_GameBoard.GetCardByCoordinates(boardCoordinates2).Letter &&
            ////                boardCoordinates1.Column != boardCoordinates2.Column && boardCoordinates1.Row != boardCoordinates2.Row)
            ////            {
            ////                secondChoiceBoardCoordinates = boardCoordinates2;
            ////                firstChoiceBoardCoordinates = boardCoordinates1;
            ////                found = true;
            ////                break;
            ////            }
            ////        }
            ////    }
            ////}
            ////else if (this.r_AiMode != eAiModes.Random && this.r_Memory.Any())
            ////{
            ////    int cardsCheckedForMatch = 0;
            ////    foreach (BoardCoordinates boardCoordinates in this.r_Memory)
            ////    {
            ////        if (cardsCheckedForMatch > this.r_MemoryDepth)
            ////        {
            ////            break;
            ////        }

            ////        if (i_GameBoard.GetCardByCoordinates(firstChoiceBoardCoordinates).Letter == i_GameBoard.GetCardByCoordinates(boardCoordinates).Letter)
            ////        {
            ////            secondChoiceBoardCoordinates = boardCoordinates;
            ////        }

            ////        cardsCheckedForMatch++;
            ////    }
            ////}

            ////this.r_Memory.Remove(secondChoiceBoardCoordinates);
            return new[] { firstChoiceOfCoordinates, secondChoiceOfCoordinates };
        }

        ////public void SaveToMemory(BoardCoordinates i_BoardCoordinates)
        ////{
        ////    if(!r_Memory.Contains(i_BoardCoordinates))
        ////    {
        ////        this.r_Memory.Insert(0, i_BoardCoordinates);
        ////    }
        ////}
    }
}
