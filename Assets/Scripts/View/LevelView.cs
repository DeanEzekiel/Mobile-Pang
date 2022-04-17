using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MobilePang;
using TMPro;

namespace MobilePang.View
{
    public class LevelView : MVCHelper
    {
        [SerializeField]
        private List<Vector2> _lstInitBallsPositions = new List<Vector2>();
        [SerializeField]
        private List<Transform> _lstBalls = new List<Transform>();

        private void OnEnable()
        {
            for(int i = 0; i < _lstBalls.Count; i++)
            {
                // set the position of the ball
                _lstBalls[i].position = _lstInitBallsPositions[i];

                // activate the ball
                _lstBalls[i].gameObject.SetActive(true);
            }
        }

        [ContextMenu("Save children with Tag Ball")]
        private void SaveBalls()
        {
            // clear the lists
            _lstBalls.Clear();
            _lstInitBallsPositions.Clear();

            // for each child with tag ball, save the position and the ball
            foreach(Transform child in transform)
            {
                if (child.CompareTag(Tag.BALL))
                {
                    _lstBalls.Add(child);
                    _lstInitBallsPositions.Add(child.position);
                }
            }
        }
    }
}