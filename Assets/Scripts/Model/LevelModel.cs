using System.Collections;
using System.Collections.Generic;
using MobilePang.Controller;
using UnityEngine;
using MobilePang;

namespace MobilePang.Model
{
    public class LevelModel : MVCHelper
    {
        public int CurrentLevel = 0;
        public int MinIndex = 0;
        public int MaxIndex = 0;
        public List<GameObject> Levels = new List<GameObject>();

        private void Awake()
        {
            MinIndex = 0;
            MaxIndex = GetIndex(Levels.Count);
        }

        public void SetLevel(int level)
        {
            CurrentLevel = level;
        }

        public int GetIndex()
        {
            return CurrentLevel - 1;
        }

        public int GetIndex(int level)
        {
            return level - 1;
        }

        public int GetNextIndex()
        {
            return CurrentLevel;
        }

        public int GetPrevIndex()
        {
            return CurrentLevel - 2;
        }

        public void ActivateLevelWithIndex(int index)
        {
            Levels[index].SetActive(true);
        }

        public void DeactivateLevelWithIndex(int index)
        {
            Levels[index].SetActive(false);
        }

        [ContextMenu("Save children with Tag Level")]
        private void SaveLevels()
        {
            // clear the levels
            Levels.Clear();

            // for each child with tag level, save the level game object
            foreach(Transform child in transform)
            {
                if (child.CompareTag(Tag.LEVEL))
                {
                    Levels.Add(child.gameObject);
                }
            }
        }
    }
}