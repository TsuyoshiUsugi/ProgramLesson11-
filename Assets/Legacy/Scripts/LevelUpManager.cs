using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScene;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] GameObject _UI;
    [SerializeField] List<Item> _items;
    [SerializeField] Button _one;
    [SerializeField] Button _two;
    [SerializeField] Button _three;
    [SerializeField] Player _player;
    [SerializeField] PoseManager _poseManager;
    
    public void LevelUp()
    {
        _UI.SetActive(true);
    }

    private void Start()
    {
        _one.onClick.AddListener(() =>
        {
            _player.GetItem(_items[0]);
            _poseManager.UnPose();
            _UI.SetActive(false);
        });

        _two.onClick.AddListener(() =>
        {
            _player.GetItem(_items[1]);
            _poseManager.UnPose();
            _UI.SetActive(false);
        }); 

        _three.onClick.AddListener(() => {
            _player.GetItem(_items[2]);
            _poseManager.UnPose();
            _UI.SetActive(false);
        });
    }
}
