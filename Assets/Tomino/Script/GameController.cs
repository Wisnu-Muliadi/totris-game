﻿using Tomino.Audio;
using Tomino.Input;
using Tomino.Model;
using Tomino.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tomino
{
    public class GameController : MonoBehaviour
    {
        public GameConfig gameConfig;
        public AlertView alertView;
        public SettingsView settingsView;
        public AudioPlayer audioPlayer;
        public GameObject screenButtons;
        [Tooltip("Wisnu note: kosongkan")]
        public AudioSource musicAudioSource; // leave empty in inspector


        private Game _game;
        private UniversalInput _universalInput;

        internal void Awake()
        {
            audioPlayer = AudioPlayer.instance; // wiss added
            musicAudioSource = audioPlayer.musicSource; // wiss added
            //audioPlayer.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume"); // Wiss commented
            Application.targetFrameRate = 60;

            HandlePlayerSettings();
            Settings.changedEvent += HandlePlayerSettings;
        }

        internal void Start()
        {
            Board board = new(10, 20);

            gameConfig.boardView.SetBoard(board);
            gameConfig.nextPieceView.SetBoard(board);

            _universalInput = new UniversalInput(new KeyboardInput(), gameConfig.boardView.touchInput);

            _game = new Game(board, _universalInput);
            _game.FinishedEvent += OnGameFinished;
            _game.PieceFinishedFallingEvent += audioPlayer.PlayPieceDropClip;
            _game.PieceRotatedEvent += audioPlayer.PlayPieceRotateClip;
            _game.PieceMovedEvent += audioPlayer.PlayPieceMoveClip;
            _game.Start();

            gameConfig.popUpText.game = _game; // Wiss added
            _game.AssignPopUpText(gameConfig.popUpText); // Wiss Added
            gameConfig.scoreView.game = _game;
            gameConfig.levelView.game = _game;
        }

        public void OnPauseButtonTap()
        {
            _game.Pause();
            ShowPauseView();
        }

        public void OnMoveLeftButtonTap()
        {
            _game.SetNextAction(PlayerAction.MoveLeft);
        }

        public void OnMoveRightButtonTap()
        {
            _game.SetNextAction(PlayerAction.MoveRight);
        }

        public void OnMoveDownButtonTap()
        {
            _game.SetNextAction(PlayerAction.MoveDown);
        }

        public void OnRotateButtonTap()
        {
            _game.SetNextAction(PlayerAction.Rotate);
        }

        private void OnGameFinished()
        {
            alertView.SetTitle(TextID.GameFinished);
            alertView.AddButton(TextID.PlayAgain, _game.Start, audioPlayer.PlayNewGameClip);
            alertView.Show();
        }

        internal void Update()
        {
            _game.Update(Time.deltaTime);
        }

        private void ShowPauseView()
        {
            audioPlayer.PlayPauseClip(); // wiss added
            alertView.SetTitle(TextID.GamePaused);
            alertView.AddButton(TextID.Resume, _game.Resume, audioPlayer.PlayResumeClip);
            alertView.AddButton(TextID.NewGame, _game.Start, audioPlayer.PlayNewGameClip);
            alertView.AddButton(TextID.Settings, ShowSettingsView, audioPlayer.PlayResumeClip);
            alertView.AddButton(TextID.MainMenu, MainMenu, audioPlayer.PlayPieceDropClip);

            alertView.Show();
        }

        private void ShowSettingsView()
        {
            settingsView.Show(ShowPauseView);
        }

        private void MainMenu()
        {
            SceneManager.LoadScene(0);
        }

        private void HandlePlayerSettings()
        {
            screenButtons.SetActive(Settings.ScreenButtonsEnabled);
            gameConfig.boardView.touchInput.Enabled = !Settings.ScreenButtonsEnabled;
            musicAudioSource.enabled = Settings.MusicEnabled; // wis changed
        }
    }
}
