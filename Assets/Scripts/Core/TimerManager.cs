using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class TimerManager : MonoBehaviour
    {
        [SerializeField] IntVariable timer;
        [SerializeField] IntVariable timerDefaultConfig;
        [SerializeField] BoolVariable HasTimeEnded;
        [SerializeField] GameEventBool OnTimeEnded;
        [SerializeField] GameEventBool OnInGame;

        public void StartClockCount(bool value)
        {
            if (value)
            {
                ResetTimerToInitConf();
                StartCoroutine(TimeCounter());
            }
            else if (!value)
            {
                StopCoroutine(TimeCounter());
            }
        }

        void ResetTimerToInitConf()
        {
            timer.Value = timerDefaultConfig.Value;
            HasTimeEnded.SetValue(false);
        }

        IEnumerator TimeCounter()
        {
            while (!HasTimeEnded.Value)
            {
                CountTime();
                yield return new WaitForSeconds(1);
            }
        }
        
        void CountTime()
        {
            timer.ApplyChange(-1);
            if (timer.Value <= 0)
            {
                HasTimeEnded.SetValue(true);
                OnTimeEnded.Raise(HasTimeEnded.Value);
            }
        }
    }
}    

//EOF.