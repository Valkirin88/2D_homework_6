using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private GenerateLevelView _generateLevelView;

    private GenerateLevelController _generateLevelController;

    private void Awake()
    {
       _generateLevelController = new GenerateLevelController(_generateLevelView);
        _generateLevelController.Awake();
    }
}
