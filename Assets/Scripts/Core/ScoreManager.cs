using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] IntVariable Points;
        [SerializeField] IntVariable PointsToWin;
        [SerializeField] BoolVariable InGame;
        [SerializeField] BoolVariable HasPlayerWin;

        public void ResetConf(bool value)
        {   
            if (value)
            {
                ResetScore();
            }
        }

        public void UpdateScore(int value)
        {
            if (InGame.Value)
            {
                Points.ApplyChange(value);
                CheckWinCondition(Points);
                if (Points.Value < 0)
                {
                    Points.SetValue(0);
                }
            }
        }

        void CheckWinCondition(IntVariable points)
        {
            //Player was winning and score dropped below point to win condition
            if (HasPlayerWin.Value && points.Value < PointsToWin.Value)
            {
                HasPlayerWin.SetValue(false);
            }
            //Player has gain points above win condition
            else if (!HasPlayerWin.Value && points.Value >= PointsToWin.Value)
            {
                HasPlayerWin.SetValue(true);
            }
        }
        
        private void ResetScore()
        {
            Points.SetValue(0);
            HasPlayerWin.SetValue(false);
        }
    }
}
//EOF.