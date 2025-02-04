using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    
    public WaveService waveService { get; private set; }
    public MapService mapService { get; private set; }

    public EventService eventService { get; private set; }
    public UIService uiService => uIService;
    [SerializeField] private UIService uIService;
    
    [SerializeField] public PlayerScriptableObject playerScriptableObject;
    [SerializeField] public SoundScriptableObject soundScriptableObject;
    [SerializeField] public MapScriptableObject mapScriptableObject;  
    [SerializeField] public WaveScriptableObject waveScriptableObject;
    
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundEffects;
    private void Start()
    {
        eventService = new EventService();
        uiService.SubscribeToEvents();
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundEffects);
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}
