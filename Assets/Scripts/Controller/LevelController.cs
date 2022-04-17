using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.View;

namespace MobilePang.Controller
{
    public class LevelController : MVCHelper
    {
        public void SetLevel(int level)
        {
            Model.Level.SetLevel(level);
        }

        public void StartLevel()
        {
            int index = Model.Level.GetIndex();

            Model.Level.DeactivateLevelWithIndex(index);
            Model.Level.ActivateLevelWithIndex(index);
        }

        public void NextLevel()
        {
            int index = Model.Level.GetIndex();
            int nextIndex = Model.Level.GetNextIndex();

            Model.Level.DeactivateLevelWithIndex(index);
            Model.Level.ActivateLevelWithIndex(nextIndex);

            SetLevel(Model.Level.CurrentLevel + 1);
        }

        public void PreviousLevel()
        {
            int index = Model.Level.GetIndex();
            int prevIndex = Model.Level.GetPrevIndex();

            Model.Level.DeactivateLevelWithIndex(index);
            Model.Level.ActivateLevelWithIndex(prevIndex);

            SetLevel(Model.Level.CurrentLevel - 1);
        }

        public void DeactivateLevels()
        {
            for(int i = 0; i < Model.Level.Levels.Count; i++)
            {
                Model.Level.DeactivateLevelWithIndex(i);
            }
        }
    }
}